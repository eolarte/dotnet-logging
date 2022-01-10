using BenchmarkDotNet.Running;
using DotnetLogging.Benchmarks;

Console.WriteLine("Running Benchmark for DotNet Default Logger...");
BenchmarkRunner.Run(typeof(LoggingDefaultDotNetLogger));

Console.WriteLine("Running Benchmark for Custom Wrapper Logger...");
BenchmarkRunner.Run(typeof(LoggingCustomLoggerWrapper));

Console.WriteLine("Running Benchmark for Serilog Logger...");
BenchmarkRunner.Run(typeof(LoggingUsingSerilogLogger));