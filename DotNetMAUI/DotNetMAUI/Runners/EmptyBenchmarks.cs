using BenchmarkDotNet.Attributes;

namespace DotNetMAUI.Runners
{
    public class EmptyBenchmarks
    {
        [Benchmark]
        public void Test1()
        {
        }

        [Benchmark(Description = "Test2 - description")]
        public void Test2()
        {
        }
    }
}

