# Logging Benchmarking

This example tries to log Information messages with Warning as minimum level of logging. So message should not be logged in console but method for logging information messages is called. 


## Results Using Dotnet Default Logger
This approach uses DotNet default logger and does not check if level is activated.

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Core i5-8350U CPU 1.70GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores


|                    Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------------- |-----------:|----------:|----------:|-------:|----------:|
|             LogInfoString |  39.347 ns | 0.8208 ns | 1.9348 ns |      - |         - |
|      LogIfInfoIsActivated |   8.511 ns | 0.2084 ns | 0.5191 ns |      - |         - |
| LogInfoUsingInterpolation | 110.632 ns | 2.2091 ns | 2.3638 ns | 0.0254 |      80 B |
|    LogInfoUsingParameters |  97.382 ns | 1.9192 ns | 4.2528 ns | 0.0178 |      56 B |
|    LogUsingManyParameters | 149.888 ns | 2.7522 ns | 4.5983 ns | 0.0381 |     120 B |


## Results Using Custom wrapper Logger
This approach wrapps DotNet implementaiton and adds condition to log only if the level is enabled.

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Core i5-8350U CPU 1.70GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores


|                    Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|-------------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|             LogInfoString | 10.592 ns | 0.2428 ns | 0.3780 ns | 10.534 ns |      - |         - |
|      LogIfInfoIsActivated |  9.004 ns | 0.3807 ns | 1.0357 ns |  8.660 ns |      - |         - |
| LogInfoUsingInterpolation | 82.530 ns | 1.6462 ns | 3.7158 ns | 81.592 ns | 0.0254 |      80 B |
|    LogInfoUsingParameters | 20.859 ns | 0.7801 ns | 2.2509 ns | 19.927 ns |      - |         - |
|    LogUsingManyParameters | 20.575 ns | 0.4197 ns | 0.5745 ns | 20.589 ns |      - |         - |


## Results Using Serilog

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2300 (1809/October2018Update/Redstone5)
Intel Core i5-8350U CPU 1.70GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores


|                    Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|-------------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|             LogInfoString |  2.707 ns | 0.1487 ns | 0.4194 ns |  2.588 ns |      - |         - |
|      LogIfInfoIsActivated |  2.816 ns | 0.1905 ns | 0.5435 ns |  2.591 ns |      - |         - |
| LogInfoUsingInterpolation | 82.767 ns | 1.6983 ns | 3.7277 ns | 81.840 ns | 0.0254 |      80 B |
|    LogInfoUsingParameters | 10.305 ns | 0.2413 ns | 0.3051 ns | 10.316 ns |      - |         - |
|    LogUsingManyParameters | 12.210 ns | 0.5098 ns | 1.4546 ns | 11.713 ns |      - |         - |

