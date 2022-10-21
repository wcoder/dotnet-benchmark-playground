﻿using System.Threading;
using BenchmarkDotNet.Attributes;

namespace BenchmarkXamarin
{
    public class IntroBasic
    {
        // And define a method with the Benchmark attribute
        [Benchmark]
        public void Sleep() => Thread.Sleep(2);

        // You can write a description for your method.
        [Benchmark(Description = "Thread.Sleep(2)")]
        public void SleepWithDescription() => Thread.Sleep(2);
    }
}