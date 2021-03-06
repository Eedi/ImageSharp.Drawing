// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System.Reflection;
using BenchmarkDotNet.Running;

namespace SixLabors.ImageSharp.Drawing.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new BenchmarkSwitcher(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }
}
