using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace DFC;

public class Logger
{
    public static ILogger Instance;

    public static void Initialize()
    {
        using ILoggerFactory factory = LoggerFactory.Create(
            builder => builder.AddSimpleConsole(
                    options =>
                    {
                        options.ColorBehavior = LoggerColorBehavior.Enabled;
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "HH:mm:ss ";
                    })
                .SetMinimumLevel(LogLevel.Trace));
        Instance = factory.CreateLogger("Program");
    }
}