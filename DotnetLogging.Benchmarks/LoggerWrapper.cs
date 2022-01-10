using Microsoft.Extensions.Logging;

namespace DotnetLogging.Benchmarks;

public class LoggerWrapper<T> : ILoggerWrapper<T>
{
    private readonly ILogger<T> logger;

    public LoggerWrapper(ILogger<T> logger)
    {
        this.logger = logger;
    }

    public void LogInformation(string message)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message);   
        }
    }

    public void LogWarning(string message)
    {
        if (logger.IsEnabled(LogLevel.Warning))
        {
            logger.LogWarning(message);   
        }
    }

    public void LogWarning<T0>(string message, T0 arg0)
    {
        if (logger.IsEnabled(LogLevel.Warning))
        {
            logger.LogWarning(message, arg0);   
        }
    }

    public void LogInformation<T0>(string message, T0 arg0)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, arg0);   
        }
    }

    public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, arg0, arg1, arg2);   
        }
    }
}

public interface ILoggerWrapper<T>
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogWarning<T0>(string message, T0 arg1);
    void LogInformation<T0>(string message, T0 arg1);
    void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
}