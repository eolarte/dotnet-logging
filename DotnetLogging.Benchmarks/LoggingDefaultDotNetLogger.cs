using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace DotnetLogging.Benchmarks;

[MemoryDiagnoser]
public class LoggingDefaultDotNetLogger : LoggingBase<LoggingDefaultDotNetLogger>, ILoggingPractices
{
    [Benchmark]
    public void LogInfoString()
    {
        //Should not log message given upper logging level
        logger.LogInformation(SimpleLogMessage);
    }

    [Benchmark]
    public void LogIfInfoIsActivated()
    {
        //Should skip log message given condition
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(SimpleLogMessage);
        }
    }

    [Benchmark]
    public void LogInfoUsingInterpolation()
    {
        logger.LogInformation($"I'm using interpolation, {999}");
    }

    [Benchmark]
    public void LogInfoUsingParameters()
    {
        logger.LogInformation("I'm using 1 parameter, {Number}", 999);
    }

    [Benchmark]
    public void LogUsingManyParameters()
    {
        logger.LogInformation("I'm using 3 parameters, {Number1}, {Number2}, {Number3}", 999, 888, 777);
    }
}