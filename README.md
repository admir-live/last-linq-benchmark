# LINQ Performance Benchmarks

## Overview
This repository contains benchmarks for comparing the performance of different methods to access elements in a list using C#. The benchmarks focus on comparing the use of LINQ's `Last()` method versus direct index access to fetch the last element of a list.

## Setup
The benchmarks are written using the BenchmarkDotNet library, a powerful .NET library for benchmarking code performance. Below are the specific technologies and environment used for the benchmarks:

- **BenchmarkDotNet version**: 0.13.12
- **Operating System**: Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
- **Processor**: AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
- **.NET SDK**: 8.0.202
- **Target Framework**: .NET 8.0.3 (X64 RyuJIT AVX2)

## Benchmark Results

The benchmarks were conducted to measure the performance of two different methods to fetch the last person from a list containing 10,000 person objects. The results highlight the significant performance difference between using LINQ and direct index access:

| Method                      | Mean (ns) | Error (ns)  | StdDev (ns) |
| --------------------------- | ---------:| -----------:| -----------:|
| `FetchLastPersonUsingLinq`  | 8.9460    | 0.0650      | 0.0576      |
| `FetchLastPersonUsingIndex` | 0.0417    | 0.0134      | 0.0118      |

## Conclusion
The benchmark results clearly show that accessing the last element in a list using direct index access (`_peopleList[^1]`) is significantly faster than using LINQ's `Last()` method. This illustrates the efficiency of index operations in scenarios where the overhead of LINQ methods is not justified.

## Source Code

Below is the simplified source code used for the benchmarks:

```csharp
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LINQPerformanceBenchmarks
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PeopleDataBenchmark
    {
        private List<Person>? _peopleList;

        [GlobalSetup]
        public void InitializePeopleList()
        {
            _peopleList = new List<Person>();
            for (int index = 0; index < 10000; index++)
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
}
