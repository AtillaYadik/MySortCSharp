using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkClass
    {
        private int[] intcol;
        [GlobalSetup]
        public void Setup()
        { 
            intcol = Enumerable.Range(0, 1000).Select(x => Random.Shared.Next(1, 10000)).ToArray();
        }

        [Benchmark]
        public void GetAtillaSort()
        {
            var sorted = AtillaSort.SortAndRemoveDuplicates(intcol);
        }

        [Benchmark]
        public int[] OrderBy() => intcol.OrderBy(x => x).ToArray();


        [Benchmark]
        public int[] OrderByDesc() => intcol.OrderByDescending(x => x).ToArray();


    }
}
