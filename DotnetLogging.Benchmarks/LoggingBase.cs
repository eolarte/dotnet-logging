using Microsoft.Extensions.Logging;

namespace DotnetLogging.Benchmarks;

public abstract class LoggingBase<T>
{
    protected string SimpleLogMessage = "I'm using interpolation";
    private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(
        builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
        });
    
    protected readonly ILogger<T> logger;

    protected LoggingBase()
    {
        this.logger = new Logger<T>(loggerFactory);
    }
}