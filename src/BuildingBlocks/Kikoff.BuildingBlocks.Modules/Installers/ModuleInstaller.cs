using Kikoff.BuildingBlocks.Modules.Abstractions;
using Kikoff.BuildingBlocks.Modules.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Kikoff.BuildingBlocks.Modules.Installers;

internal class ModuleInstaller
{
    private readonly IKikoffModule _module;
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _hostServices;

    private readonly ILogger _log;

    public ModuleInstaller(IKikoffModule module, IConfiguration configuration, IServiceCollection hostServices)
    {
        _module = module;
        _configuration = configuration;
        _hostServices = hostServices;

        _log = Log.ForContext<ModuleInstaller>().ForContext("ModuleName", _module.Name);

    }

    public void ConfigureModule()
    {
        _log.Information("Configuring module");

        _module.SetConfiguration(_configuration);
     }

    public void ScanCoreModuleServices()
    {
        _module.Services.Scan(x => x.FromAssemblies(_module.ApplicationAssembly)
            .AddEndpointDefinitions());
    }

    public void RegisterModuleServices()
    {
        _module.ConfigureServices();

        foreach (ServiceDescriptor service in _module.Services)
        {
            _hostServices.Add(service);
        }
    }
}
