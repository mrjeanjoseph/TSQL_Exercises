using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

public class SortingBenchmark
{
    [Params(100, 1_000, 10_000, 100_000)]
    public int SequenceLength { get; set; }

    [Benchmark(Baseline = true)] public List<Worker> ToList() =>
        new List<Worker>(Workers.GetWorkers(this.SequenceLength));

    [Benchmark] public List<Worker> ListSort()
    {
        List<Worker> list = new List<Worker>(Workers.GetWorkers(this.SequenceLength));
        list.Sort(Worker.RateComparer);
        return list;
    }

    [Benchmark] public List<Worker> SequenceOrderBy() =>
        Workers.GetWorkers(this.SequenceLength).OrderBy(worker => worker.Rate).ToList();
}