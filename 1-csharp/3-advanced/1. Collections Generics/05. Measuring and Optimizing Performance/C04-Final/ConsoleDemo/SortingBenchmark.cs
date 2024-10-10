using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

public class SortingBenchmark
{
    [Params(100, 1_000, 10_000, 100_000)]
    public int SequenceLength { get; set; }

    [Benchmark] public List<Worker> ToList() =>
        new List<Worker>(Workers.GetWorkers(this.SequenceLength));

    [Benchmark] public List<Worker> ListSort()
    {
        List<Worker> list = new List<Worker>(Workers.GetWorkers(this.SequenceLength));
        list.Sort(Worker.RateComparer);
        return list;
    }

    [Benchmark(Baseline = true)] public List<Worker> FullOrderByHourlyRate()
    {
        List<Worker> list = Workers.GetWorkers(this.SequenceLength).ToList();
        list.Sort(Comparer<Worker>.Create((a, b) => a.HourlyRate.CompareTo(b.HourlyRate)));
        return list;
    }
}