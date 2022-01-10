using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace DotnetLogging.Benchmarks;

[MemoryDiagnoser]
public class LoggingCustomLoggerWrapper : LoggingBase<LoggingCustomLoggerWrapper>, ILoggingPractices
{
    private readonly ILoggerWrapper<LoggingCustomLoggerWrapper> myLogger;

    public LoggingCustomLoggerWrapper()
    {
        this.myLogger = new LoggerWrapper<LoggingCustomLoggerWrapper>(logger);
    }

    [Benchmark]
    public void LogInfoString()
    {
        //Should log message since level is Warning
        myLogger.LogInformation(SimpleLogMessage);
    }

    [Benchmark]
    public void LogIfInfoIsActivated()
    {
        //Should skip log message given condition
        if (logger.IsEnabled(LogLevel.Information))
        {
            myLogger.LogInformation(SimpleLogMessage);
        }
    }

    [Benchmark]
    public void LogInfoUsingInterpolation()
    {
        myLogger.LogInformation($"I'm using interpolation, {999}");
    }

    [Benchmark]
    public void LogInfoUsingParameters()
    {
        myLogger.LogInformation("I'm using 1 parameter, {Number}", 999);
    }

    [Benchmark]
    public void LogUsingManyParameters()
    {
        myLogger.LogInformation("I'm using log wrapper with 3 parameters, {Number1}, {Number2}, {Number3}", 999, 888, 777);
    }
}