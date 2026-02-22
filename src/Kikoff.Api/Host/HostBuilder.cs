using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kikoff.BuildingBlocks.Http.Cors;
using Kikoff.BuildingBlocks.Modules;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Kikoff.Api.Host;

internal class KikoffHostBuilder
{
    private readonly IKikoffModule[] _modules;
    private readonly WebApplicationBuilder _webAppBuilder;
    private readonly ConfigurationSetup _configurationSetup;

    private ConfigurationManager Configuration => _webAppBuilder.Configuration;
    private ConfigureHostBuilder Host => _webAppBuilder.Host;
    private IServiceCollection Services => _webAppBuilder.Services;


    public KikoffHostBuilder(IKikoffModule[] modules, params string[] args)
    {
        _modules = modules;
        _webAppBuilder = WebApplication.CreateBuilder(args);

        _configurationSetup = new ConfigurationSetup(
            Assembly.GetExecutingAssembly(),
            _webAppBuilder);
    }

    internal void SetupConfiguration()
    {
        Log.Information("Setting up configuration for environment: {Environment}",
            _webAppBuilder.Environment.EnvironmentName);

        _configurationSetup
            .ClearAllSources()
            .AddAppsettingsJson()
            .AddUserSecrets()
            .AddCliOverrides();
    }

    internal void ConfigureDependencyInjectionContainer()
    {
        Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        Host.ConfigureContainer<ContainerBuilder>(builder =>
        {
            foreach (IKikoffModule module in _modules) // this will be moved to separate method
            {
                Log.Information("Registering module: {ModuleName}", module.GetType().Name);
            }
        });

        Services.AddLogging(lb => lb.AddSerilog());
        Services.AddOptions();
        Services.AddMemoryCache();

        if (_webAppBuilder.Environment.IsDevelopment())
        {
            Services.AddOpenApi();
        }

        _webAppBuilder.AddKikoffCors();

        // AUTH GOES HERE
    }

    internal KikoffApplication Build()
    {
        // Logging is configured as late as possible to ensure we have consistent logging during API startup.
        // Also we need to set Log.Logger after we override global logger to make sure .NET will use the same
        // configuration.
        Host.UseSerilog(new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger());

        WebApplication webApplication = _webAppBuilder.Build();

        return new KikoffApplication(webApplication);
    }
}

internal class KikoffApplication : IAsyncDisposable
{
    private readonly WebApplication _application;
    private bool _configured = false;
    private bool _running = false;

    public KikoffApplication(WebApplication application)
    {
        _application = application;
    }

    public void ConfigureRequestPipeline()
    {
        _application.UseHttpsRedirection();
        _application.UseSerilogRequestLogging();
        _application.UseKikoffCors();
        // AUTH GOES HERE

        if (_application.Environment.IsDevelopment())
        {
            _application.MapOpenApi();
        }

        _configured = true;
    }

    public async Task RunAsync()
    {
        if (!_configured)
        {
            throw new InvalidOperationException("TalentFlow API Request Pipeline not configured");
        }

        if (_running)
        {
            throw new InvalidOperationException("Already running");
        }

        ConfigureApplicationLifetime();

        OverrideGlobalLogger();

        _running = true;

        await _application.RunAsync();
    }

    private void OverrideGlobalLogger()
    {
        // Logging is configured as late as possible to ensure we have consistent logging during API startup.

        Log.Information("Overriding global logger configuration");

        ILogger logger = _application.Services.GetRequiredService<ILogger>();

        Log.Logger = logger;
    }

    private void ConfigureApplicationLifetime()
    {
        _application.Lifetime.ApplicationStopping.Register(() => { Log.Warning("Stopping application"); });

        _application.Lifetime.ApplicationStopped.Register(() => { Log.Warning("Application stopped"); });
    }

    public async ValueTask DisposeAsync()
    {
        await _application.DisposeAsync();
    }
}
