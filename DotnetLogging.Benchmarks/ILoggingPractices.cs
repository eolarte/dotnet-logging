namespace DotnetLogging.Benchmarks;

public interface ILoggingPractices
{
    public void LogInfoString();
    public void LogIfInfoIsActivated();
    // public void LogWarningSimpleString();
    public void LogInfoUsingInterpolation();
    public void LogInfoUsingParameters();
    // public void LogWarningUsingParameters();
    public void LogUsingManyParameters();
}