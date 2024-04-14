using BenchmarkDotNet.Attributes;

namespace LINQPerformanceBenchmarks;

public class PeopleDataBenchmark
{
    private List<Person>? _peopleList;

    [GlobalSetup]
    public void InitializePeopleList()
    {
        _peopleList = new List<Person>();
        for (var index = 0; index < 10000; index++)
        {
            _peopleList.Add(new Person { Name = $"Person{index}", Age = index });
        }
    }

    [Benchmark]
    public void FetchLastPersonUsingLinq() 
    {
        var lastPerson = _peopleList!.Last();
    }

    [Benchmark]
    public void FetchLastPersonUsingIndex()
    {
        var lastPerson = _peopleList![^1];
    }
}