using Kikoff.BuildingBlocks.Http.Cors;
using Kikoff.BuildingBlocks.Http.Endpoints;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Kikoff.Api.Host;

internal class KikoffApplication : IAsyncDisposable
{
    private readonly WebApplication _application;
    private bool _configured;
    private bool _running;

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

        MapEndpoints();

        if (_application.Environment.IsDevelopment())
        {
            _application.MapOpenApi();
        }

        _configured = true;
    }

    private void MapEndpoints()
    {
        IEnumerable<IEndpointDefinition> endpoints = _application.Services.GetServices<IEndpointDefinition>();

        foreach (IEndpointDefinition endpoint in endpoints)
        {
            endpoint.Map(_application);
        }
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

        ILogger logger = _application.Services.GetRequiredService<ILogger>();

        Log.Information("Overriding global logger configuration.");

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
