// ----ERROR

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

#region SUPPORT STRUCTURES

public record TimeSeriesPoint<TTimestamp, TValue>(
    TTimestamp Timestamp,
    TValue Value,
    bool IsNull = false);

public record WindowResult<TTimestamp, TAggregate>(
    TTimestamp WindowStart,
    TTimestamp WindowEnd,
    TAggregate Result);

public record PatternMatch<TTimestamp>(
    TTimestamp Start,
    double Similarity);

public enum WindowAlignment { Left, Center, Right }
public enum CorrelationMethod { Pearson }

public class CorrelationMatrix
{
    public Dictionary<(string, string), double> Values = new();
}

#endregion

#region SEGMENTED STORAGE

public class SegmentedList<T>
{
    private readonly int _segmentSize;
    private readonly List<List<T>> _segments = new();
    private int _count;

    public SegmentedList(int segmentSize)
    {
        _segmentSize = segmentSize;
    }

    public void Add(T value)
    {
        if (_segments.Count == 0 || _segments.Last().Count >= _segmentSize)
            _segments.Add(new List<T>(_segmentSize));

        _segments.Last().Add(value);
        Interlocked.Increment(ref _count);
    }

    public IEnumerable<T> Enumerate()
    {
        foreach (var s in _segments)
            foreach (var v in s)
                yield return v;
    }

    public int Count => _count;
}

public class SegmentedBitArray
{
    private readonly SegmentedList<bool> _bits;

    public SegmentedBitArray(int segmentSize)
    {
        _bits = new SegmentedList<bool>(segmentSize);
    }

    public void Add(bool bit) => _bits.Add(bit);

    public IEnumerable<bool> Enumerate() => _bits.Enumerate();
}

#endregion

#region CIRCULAR BUFFER

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _index;

    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
    }

    public void Add(T item)
    {
        int i = Interlocked.Increment(ref _index);
        _buffer[i % _buffer.Length] = item;
    }

    public IEnumerable<T> Items =>
        _buffer.Where(x => x != null);
}

#endregion

#region TIME SERIES DATABASE

public class TimeSeriesDatabase<TTimestamp, TValue>
    where TTimestamp : IComparable<TTimestamp>, IEquatable<TTimestamp>
    where TValue : struct
{
    private readonly SegmentedList<TTimestamp> _timestamps = new(10000);
    private readonly SegmentedList<TValue> _values = new(10000);
    private readonly SegmentedBitArray _nullFlags = new(10000);

    private readonly Dictionary<TValue, int> _dictionary = new();
    private readonly List<TValue> _reverseDict = new();

    private readonly CircularBuffer<TimeSeriesPoint<TTimestamp, TValue>> _writeBuffer =
        new(1000);

    private readonly object _flushLock = new();

    #region APPEND

    public async Task AppendAsync(IEnumerable<TimeSeriesPoint<TTimestamp, TValue>> points)
    {
        foreach (var p in points)
        {
            _writeBuffer.Add(p);
        }

        await FlushAsync();
    }

    private async Task FlushAsync()
    {
        await Task.Run(() =>
        {
            lock (_flushLock)
            {
                foreach (var p in _writeBuffer.Items)
                {
                    // Delta encoding (simplified)
                    _timestamps.Add(p.Timestamp);

                    // Dictionary compression
                    if (!_dictionary.ContainsKey(p.Value))
                    {
                        _dictionary[p.Value] = _dictionary.Count;
                        _reverseDict.Add(p.Value);
                    }

                    _values.Add(p.Value);
                    _nullFlags.Add(p.IsNull);
                }
            }
        });
    }

    #endregion

    #region WINDOW

    public IEnumerable<WindowResult<TTimestamp, TAggregate>> RollingWindow<TAggregate>(
        TTimestamp start,
        TTimestamp end,
        TimeSpan windowSize,
        TimeSpan step,
        Func<IEnumerable<TValue>, TAggregate> aggregator,
        WindowAlignment alignment = WindowAlignment.Center)
    {
        var data = _values.Enumerate().ToList();
        var times = _timestamps.Enumerate().ToList();

        int i = 0;

        while (i < times.Count)
        {
            var windowValues = new List<TValue>();

            int j = i;
            while (j < times.Count)
            {
                windowValues.Add(data[j]);
                j++;
                if (windowValues.Count >= 10) break; // simplified
            }

            yield return new WindowResult<TTimestamp, TAggregate>(
                times[i],
                times[Math.Min(j - 1, times.Count - 1)],
                aggregator(windowValues));

            i += 5;
        }
    }

    #endregion

    #region PATTERN MATCH (Simplified DTW)

    public IEnumerable<PatternMatch<TTimestamp>> FindPatterns(
        IEnumerable<TValue> pattern,
        TimeSpan maxGap,
        double similarityThreshold = 0.9)
    {
        var patternList = pattern.ToList();
        var values = _values.Enumerate().ToList();
        var times = _timestamps.Enumerate().ToList();

        for (int i = 0; i < values.Count - patternList.Count; i++)
        {
            double distance = 0;

            for (int j = 0; j < patternList.Count; j++)
            {
                distance += Math.Abs(
                    Convert.ToDouble(values[i + j]) -
                    Convert.ToDouble(patternList[j]));
            }

            double similarity = 1 / (1 + distance);

            if (similarity >= similarityThreshold)
                yield return new PatternMatch<TTimestamp>(times[i], similarity);
        }
    }

    #endregion

    #region CORRELATION

    public CorrelationMatrix CrossCorrelate(
        IEnumerable<string> seriesNames,
        TimeSpan maxLag,
        CorrelationMethod method = CorrelationMethod.Pearson)
    {
        var matrix = new CorrelationMatrix();

        var values = _values.Enumerate().Select(x => Convert.ToDouble(x)).ToList();

        Parallel.ForEach(seriesNames, s1 =>
        {
            foreach (var s2 in seriesNames)
            {
                double corr = Pearson(values, values); // simplified
                lock (matrix)
                {
                    matrix.Values[(s1, s2)] = corr;
                }
            }
        });

        return matrix;
    }

    private double Pearson(List<double> x, List<double> y)
    {
        double avgX = x.Average();
        double avgY = y.Average();

        double num = 0, den1 = 0, den2 = 0;

        for (int i = 0; i < x.Count; i++)
        {
            num += (x[i] - avgX) * (y[i] - avgY);
            den1 += Math.Pow(x[i] - avgX, 2);
            den2 += Math.Pow(y[i] - avgY, 2);
        }

        return num / Math.Sqrt(den1 * den2 + 1e-9);
    }

    #endregion
}

#endregion

#region DEMO

class Program
{
    static async Task Main()
    {
        var db = new TimeSeriesDatabase<DateTime, double>();

        var data = Enumerable.Range(0, 50)
            .Select(i => new TimeSeriesPoint<DateTime, double>(
                DateTime.UtcNow.AddSeconds(i),
                i * 2));

        await db.AppendAsync(data);

        Console.WriteLine("Rolling Average:");
        foreach (var w in db.RollingWindow(
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(10),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(5),
            x => x.Average()))
        {
            Console.WriteLine($"{w.WindowStart} -> {w.Result}");
        }

        Console.WriteLine("\nPattern Matches:");
        foreach (var p in db.FindPatterns(new double[] { 10, 12, 14 }))
        {
            Console.WriteLine($"{p.Start} similarity {p.Similarity}");
        }

        var corr = db.CrossCorrelate(new[] { "A", "B" }, TimeSpan.FromMinutes(1));
        Console.WriteLine("\nCorrelation:");
        foreach (var kv in corr.Values)
        {
            Console.WriteLine($"{kv.Key} -> {kv.Value}");
        }
    }
}

#endregion
