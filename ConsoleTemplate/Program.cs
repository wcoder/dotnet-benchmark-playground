using BenchmarkDotNet.Running;

namespace ConsoleTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}