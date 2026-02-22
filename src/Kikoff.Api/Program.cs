using System.Globalization;
using Kikoff.Api.Host;
using Kikoff.Modules.Sample.Infrastructure;
using Serilog;
using Serilog.Formatting.Json;

namespace Kikoff.Api;

// ReSharper disable once ClassNeverInstantiated.Global
public static class Program
{
    public static async Task Main(string[] args)
    {
        ConfigureStartupLogger();

        try
        {
            var hostBuilder = new KikoffHostBuilder([
                new SampleKikoffModule()
            ], args);

            hostBuilder.SetupConfiguration();
            hostBuilder.ConfigureDependencyInjectionContainer();

            KikoffApplication application = hostBuilder.Build();

            application.ConfigureRequestPipeline();

            await application.RunAsync();
        }
        finally
        {
            Log.Warning("TalentFlow Backend API stopped");
            await Log.CloseAndFlushAsync();
        }
    }

    private static void ConfigureStartupLogger()
    {
        // WARNING! Logs produced by this logger will not be sent to any external logging system.
        // After application starts up, this logger will be overriden by the one configured in appsettings.
        const string template = "[{Timestamp:HH:mm:ss} {Level:u3}] STARTUP {Message:lj}{NewLine}{Exception}";
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: template, formatProvider: CultureInfo.InvariantCulture)
            .WriteTo.File(
                path: "logs/log.txt",
                rollingInterval: RollingInterval.Day,
                shared: true,
                formatter: new JsonFormatter())
            .CreateLogger();
    }
}
