using BenchmarkDotNet.Attributes;
using Serilog;
using Serilog.Events;

namespace DotnetLogging.Benchmarks;

[MemoryDiagnoser]
public class LoggingUsingSerilogLogger : ILoggingPractices
{
    private readonly ILogger serilogLogger;
    private string SimpleLogMessage = "I'm using interpolation";

    public LoggingUsingSerilogLogger()
    {
        serilogLogger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.Console().CreateLogger();
    }

    [Benchmark]
    public void LogInfoString()
    {
        //Should log message since level is Warning
        serilogLogger.Information(SimpleLogMessage);
    }

    [Benchmark]
    public void LogIfInfoIsActivated()
    {
        //Should skip log message given condition
        if (serilogLogger.IsEnabled(LogEventLevel.Information))
        {
            serilogLogger.Information(SimpleLogMessage);
        }
    }

    [Benchmark]
    public void LogInfoUsingInterpolation()
    {
        serilogLogger.Information($"I'm using interpolation, {999}");
    }

    [Benchmark]
    public void LogInfoUsingParameters()
    {
        serilogLogger.Information("I'm using 1 parameter, {Number}", 999);
    }

    [Benchmark]
    public void LogUsingManyParameters()
    {
        serilogLogger.Information("I'm using 3 parameters, {Number1}, {Number2}, {Number3}", 999, 888, 777);
    }
}