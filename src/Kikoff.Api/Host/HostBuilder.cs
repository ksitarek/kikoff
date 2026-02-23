using System.Reflection;
using Kikoff.BuildingBlocks.Http.Cors;
using Kikoff.BuildingBlocks.Modules.Abstractions;
using Kikoff.BuildingBlocks.Modules.Installers;
using Serilog;

namespace Kikoff.Api.Host;

internal class KikoffHostBuilder
{
    private readonly WebApplicationBuilder _webAppBuilder;
    private readonly ConfigurationSetup _configurationSetup;
    private readonly ModulesInstaller _modulesInstaller;

    private ConfigurationManager Configuration => _webAppBuilder.Configuration;
    private ConfigureHostBuilder Host => _webAppBuilder.Host;
    private IServiceCollection Services => _webAppBuilder.Services;

    public KikoffHostBuilder(IKikoffModule[] modules, params string[] args)
    {
        _webAppBuilder = WebApplication.CreateBuilder(args);

        _configurationSetup = new ConfigurationSetup(
            Assembly.GetExecutingAssembly(),
            _webAppBuilder);

        _modulesInstaller = new ModulesInstaller(modules, Configuration, Services);
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

    public void InstallModules() => _modulesInstaller.InstallModules();
}
