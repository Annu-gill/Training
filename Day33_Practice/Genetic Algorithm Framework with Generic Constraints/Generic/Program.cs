// ----ERROR

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#region CHROMOSOME INTERFACE

public interface IChromosome<TGene, TFitness> : 
    IComparable<IChromosome<TGene, TFitness>>
    where TFitness : IComparable<TFitness>
{
    IReadOnlyList<TGene> Genes { get; }
    TFitness Fitness { get; }
    IChromosome<TGene, TFitness> Crossover(IChromosome<TGene, TFitness> other);
    void Mutate(double mutationRate);
}

#endregion

#region SAMPLE CHROMOSOME (Span optimized)

public class DoubleChromosome : IChromosome<double, double>
{
    private double[] _genes;
    public IReadOnlyList<double> Genes => _genes;
    public double Fitness { get; private set; }

    public DoubleChromosome(int length, Random rand)
    {
        _genes = new double[length];
        for (int i = 0; i < length; i++)
            _genes[i] = rand.NextDouble();
    }

    public int CompareTo(IChromosome<double, double> other)
        => Fitness.CompareTo(other.Fitness);

    public IChromosome<double, double> Crossover(IChromosome<double, double> other)
    {
        var child = new DoubleChromosome(_genes.Length, new Random());
        Span<double> span = _genes;

        for (int i = 0; i < span.Length; i++)
            child._genes[i] = (i % 2 == 0) ? _genes[i] : other.Genes[i];

        return child;
    }

    public void Mutate(double rate)
    {
        var rand = new Random();
        for (int i = 0; i < _genes.Length; i++)
            if (rand.NextDouble() < rate)
                _genes[i] = rand.NextDouble();
    }

    public void EvaluateFitness()
    {
        Fitness = _genes.Sum();
    }
}

#endregion

#region POPULATION

public class Population<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    public List<TChromosome> Chromosomes { get; } = new();

    public TChromosome Best => Chromosomes.Max();

    public void Add(TChromosome c) => Chromosomes.Add(c);
}

#endregion

#region STRATEGIES (Variance)

public abstract class SelectionStrategy<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    public abstract IEnumerable<TChromosome> Select(
        IEnumerable<TChromosome> population, int count);
}

public class TournamentSelection<TGene, TFitness, TChromosome>
    : SelectionStrategy<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    private Random _rand = new();

    public override IEnumerable<TChromosome> Select(
        IEnumerable<TChromosome> population, int count)
    {
        var list = population.ToList();

        for (int i = 0; i < count; i++)
        {
            var a = list[_rand.Next(list.Count)];
            var b = list[_rand.Next(list.Count)];
            yield return a.CompareTo(b) > 0 ? a : b;
        }
    }
}

public abstract class CrossoverStrategy<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    public abstract TChromosome Crossover(TChromosome p1, TChromosome p2);
}

public class SinglePointCrossover<TGene, TFitness, TChromosome>
    : CrossoverStrategy<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    public override TChromosome Crossover(TChromosome p1, TChromosome p2)
        => (TChromosome)p1.Crossover(p2);
}

#endregion

#region DIVERSITY CACHE

public class GeneticDiversityCache<TGene>
{
    private HashSet<int> _hashes = new();

    public bool IsDiverse(IEnumerable<TGene> genes)
    {
        int hash = string.Join(",", genes).GetHashCode();
        return _hashes.Add(hash);
    }
}

#endregion

#region ELITE POOL

public class AdaptiveSortedList<TKey, TValue>
    where TKey : IComparable<TKey>
{
    private SortedDictionary<TKey, List<TValue>> _data = new();

    public void Add(TKey key, TValue value)
    {
        if (!_data.ContainsKey(key))
            _data[key] = new List<TValue>();

        _data[key].Add(value);
    }

    public IEnumerable<TValue> Top(int n)
    {
        return _data.Reverse()
            .SelectMany(x => x.Value)
            .Take(n);
    }
}

#endregion

#region METRICS

public class EvolutionMetrics
{
    public int Generation { get; set; }
    public double BestFitness { get; set; }
}

public class PopulationStatistics
{
    public double TotalFitness;
    public int Count;

    public PopulationStatistics Accumulate<TGene, TFitness>(
        IChromosome<TGene, TFitness> c)
        where TFitness : IComparable<TFitness>
    {
        TotalFitness += Convert.ToDouble(c.Fitness);
        Count++;
        return this;
    }

    public PopulationStatistics Combine(PopulationStatistics other)
    {
        TotalFitness += other.TotalFitness;
        Count += other.Count;
        return this;
    }

    public PopulationStatistics Normalize()
    {
        if (Count > 0) TotalFitness /= Count;
        return this;
    }
}

#endregion

#region CONFIG

public class EvolutionConfiguration
{
    public int Generations { get; set; } = 50;
    public int OffspringCount { get; set; } = 20;
    public double MutationRate { get; set; } = 0.05;
}

#endregion

#region EVOLUTION ENGINE

public class EvolutionaryAlgorithm<TGene, TFitness, TChromosome>
    where TChromosome : class, IChromosome<TGene, TFitness>
    where TFitness : struct, IComparable<TFitness>
{
    private Population<TGene, TFitness, TChromosome> _population;
    private SelectionStrategy<TGene, TFitness, TChromosome> _selection;
    private CrossoverStrategy<TGene, TFitness, TChromosome> _crossover;

    private AdaptiveSortedList<TFitness, TChromosome> _elite = new();
    private ConcurrentBag<TChromosome> _offspring = new();
    private GeneticDiversityCache<TGene> _diversity = new();

    public EvolutionaryAlgorithm(
        Population<TGene, TFitness, TChromosome> pop,
        SelectionStrategy<TGene, TFitness, TChromosome> sel,
        CrossoverStrategy<TGene, TFitness, TChromosome> cross)
    {
        _population = pop;
        _selection = sel;
        _crossover = cross;
    }

    public async Task<(TChromosome Best, IEnumerable<EvolutionMetrics>)>
        EvolveAsync(EvolutionConfiguration config,
                    CancellationToken token)
    {
        var history = new List<EvolutionMetrics>();

        for (int gen = 0; gen < config.Generations; gen++)
        {
            token.ThrowIfCancellationRequested();

            // Parallel fitness
            await Parallel.ForEachAsync(
                _population.Chromosomes,
                token,
                async (c, t) =>
                {
                    if (c is DoubleChromosome dc)
                        dc.EvaluateFitness();

                    await Task.CompletedTask;
                });

            // Metrics
            var best = _population.Best;
            history.Add(new EvolutionMetrics
            {
                Generation = gen,
                BestFitness = Convert.ToDouble(best.Fitness)
            });

            // Selection
            var parents = _selection
                .Select(_population.Chromosomes,
                        config.OffspringCount)
                .ToList();

            _offspring = new ConcurrentBag<TChromosome>();

            // Parallel crossover
            await Task.WhenAll(
                parents
                .Chunk(2)
                .Select(pair => Task.Run(() =>
                {
                    if (pair.Length == 2)
                    {
                        var child = _crossover
                            .Crossover(pair[0], pair[1]);

                        child.Mutate(config.MutationRate);

                        if (_diversity.IsDiverse(child.Genes))
                            _offspring.Add(child);
                    }
                })));

            // Island migration (simplified)
            foreach (var elite in _population.Chromosomes.Take(2))
                _offspring.Add(elite);

            _population.Chromosomes.Clear();
            _population.Chromosomes.AddRange(_offspring);
        }

        return (_population.Best, history);
    }

    public PopulationStatistics GetStatistics()
    {
        return _population.Chromosomes
            .AsParallel()
            .Aggregate(
                () => new PopulationStatistics(),
                (acc, c) => acc.Accumulate(c),
                (a, b) => a.Combine(b),
                final => final.Normalize());
    }
}

#endregion

#region DEMO

class Program
{
    static async Task Main()
    {
        var rand = new Random();

        var pop = new Population<double, double, DoubleChromosome>();
        for (int i = 0; i < 30; i++)
            pop.Add(new DoubleChromosome(10, rand));

        var algo = new EvolutionaryAlgorithm<
            double, double, DoubleChromosome>(
            pop,
            new TournamentSelection<
                double, double, DoubleChromosome>(),
            new SinglePointCrossover<
                double, double, DoubleChromosome>());

        var config = new EvolutionConfiguration();

        var result = await algo.EvolveAsync(
            config, CancellationToken.None);

        Console.WriteLine("Best Fitness: " +
            result.Best.Fitness);

        var stats = algo.GetStatistics();
        Console.WriteLine("Average Fitness: " +
            stats.TotalFitness);
    }
}

#endregion
