


// --- ERROR

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Channels;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

#region SUPPORT CLASSES

public class CacheEntry<T>
{
    public T Value { get; set; }
    public DateTime? Expiry { get; set; }
    public long Version { get; set; } // CRDT version

    public bool IsExpired() =>
        Expiry.HasValue && DateTime.UtcNow > Expiry.Value;
}

public class CacheResult<T>
{
    public bool Found { get; set; }
    public T Value { get; set; }
}

public class CacheShard<TKey, TValue>
{
    public ConcurrentDictionary<TKey, CacheEntry<TValue>> Data = new();
}

#endregion

#region BLOOM FILTER

public class BloomFilter<TKey>
{
    private readonly BitArray _bits;
    private readonly int _hashFunctions;

    public BloomFilter(int size = 10000, int hashFunctions = 3)
    {
        _bits = new BitArray(size);
        _hashFunctions = hashFunctions;
    }

    private int Hash(TKey key, int seed)
    {
        return Math.Abs((key.GetHashCode() + seed) % _bits.Length);
    }

    public void Add(TKey key)
    {
        for (int i = 0; i < _hashFunctions; i++)
            _bits[Hash(key, i)] = true;
    }

    public bool MightContain(TKey key)
    {
        for (int i = 0; i < _hashFunctions; i++)
            if (!_bits[Hash(key, i)])
                return false;

        return true;
    }
}

#endregion

#region DISTRIBUTED CACHE

public class DistributedCache<TKey, TValue> : IDisposable
    where TKey : IEquatable<TKey>
    where TValue : class
{
    private readonly SortedDictionary<uint, CacheNode> _hashRing = new();
    private readonly ConcurrentDictionary<TKey, CacheEntry<TValue>> _localCache = new();
    private readonly ReaderWriterLockSlim _ringLock =
        new(LockRecursionPolicy.SupportsRecursion);

    private readonly Channel<(TKey, CacheEntry<TValue>)> _replicationChannel =
        Channel.CreateUnbounded<(TKey, CacheEntry<TValue>)>();

    private readonly BloomFilter<TKey> _bloom = new();

    private const int VirtualNodesPerPhysicalNode = 100;

    private class CacheNode
    {
        public string NodeId { get; set; }
        public uint Position { get; set; }
        public ConcurrentDictionary<TKey, CacheEntry<TValue>> Store =
            new();
    }

    public DistributedCache()
    {
        _ = Task.Run(ProcessReplicationAsync);
    }

    #region HASHING

    private uint Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToUInt32(bytes, 0);
    }

    private uint HashKey(TKey key) => Hash(key.ToString());

    #endregion

    #region NODE MANAGEMENT

    public void AddNode(string nodeId)
    {
        _ringLock.EnterWriteLock();
        try
        {
            for (int i = 0; i < VirtualNodesPerPhysicalNode; i++)
            {
                uint pos = Hash(nodeId + i);
                _hashRing[pos] = new CacheNode
                {
                    NodeId = nodeId,
                    Position = pos
                };
            }
        }
        finally { _ringLock.ExitWriteLock(); }
    }

    private IEnumerable<CacheNode> GetSuccessors(uint hash, int count)
    {
        _ringLock.EnterReadLock();
        try
        {
            var nodes = _hashRing
                .Where(x => x.Key >= hash)
                .Select(x => x.Value)
                .Concat(_hashRing.Values)
                .Take(count);

            return nodes;
        }
        finally { _ringLock.ExitReadLock(); }
    }

    #endregion

    #region SET

    public async Task<bool> SetAsync(
        TKey key, TValue value,
        TimeSpan? ttl = null,
        int replicationFactor = 3)
    {
        var entry = new CacheEntry<TValue>
        {
            Value = value,
            Version = DateTime.UtcNow.Ticks,
            Expiry = ttl.HasValue ?
                DateTime.UtcNow + ttl : null
        };

        _bloom.Add(key);

        uint hash = HashKey(key);

        var nodes = GetSuccessors(hash, replicationFactor);

        foreach (var node in nodes)
        {
            node.Store[key] = entry;
            await _replicationChannel.Writer
                .WriteAsync((key, entry));
        }

        return true;
    }

    #endregion

    #region GET

    public async Task<CacheResult<TValue>> GetAsync(
        TKey key, bool readRepair = false)
    {
        if (!_bloom.MightContain(key))
            return new CacheResult<TValue> { Found = false };

        uint hash = HashKey(key);

        var replicas = GetSuccessors(hash, 3).ToList();

        CacheEntry<TValue> latest = null;

        foreach (var node in replicas)
        {
            if (node.Store.TryGetValue(key, out var e))
            {
                if (latest == null || e.Version > latest.Version)
                    latest = e;
            }
        }

        if (latest == null || latest.IsExpired())
            return new CacheResult<TValue> { Found = false };

        if (readRepair)
        {
            foreach (var node in replicas)
                node.Store[key] = latest;
        }

        return new CacheResult<TValue>
        {
            Found = true,
            Value = latest.Value
        };
    }

    #endregion

    #region REPLICATION WORKER

    private async Task ProcessReplicationAsync()
    {
        await foreach (var item in _replicationChannel.Reader.ReadAllAsync())
        {
            // Simulated async replication
            await Task.Delay(1);
        }
    }

    #endregion

    #region REBALANCING

    public async Task RebalanceRingAsync()
    {
        // Minimal movement simulation
        await Task.Delay(50);
    }

    #endregion

    #region QUERY

    public async IAsyncEnumerable<KeyValuePair<TKey, TValue>> QueryAsync(
        Expression<Func<KeyValuePair<TKey, TValue>, bool>> predicate,
        [System.Runtime.CompilerServices.EnumeratorCancellation]
        CancellationToken token = default)
    {
        var compiled = predicate.Compile();

        foreach (var node in _hashRing.Values)
        {
            foreach (var kv in node.Store)
            {
                token.ThrowIfCancellationRequested();

                if (!kv.Value.IsExpired() &&
                    compiled(new KeyValuePair<TKey, TValue>(
                        kv.Key, kv.Value.Value)))
                {
                    yield return new KeyValuePair<TKey, TValue>(
                        kv.Key, kv.Value.Value);
                }
            }

            await Task.Yield();
        }
    }

    #endregion

    public void Dispose()
    {
        _ringLock.Dispose();
    }
}

#endregion

#region DEMO

class Program
{
    static async Task Main()
    {
        var cache = new DistributedCache<string, string>();

        cache.AddNode("Node1");
        cache.AddNode("Node2");
        cache.AddNode("Node3");

        await cache.SetAsync("user:1", "Anugraha");
        await cache.SetAsync("user:2", "Engineer");

        var result = await cache.GetAsync("user:1", true);
        Console.WriteLine(result.Value);

        await foreach (var item in cache.QueryAsync(
            x => x.Key.Contains("user")))
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }
    }
}

#endregion
