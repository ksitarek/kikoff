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

    public void Install()
    {
        ConfigureModule();
        ScanCoreModuleServices();
        RegisterModuleServices();
    }

    private void ConfigureModule()
    {
        _log.Debug("Configuring module");

        _module.SetConfiguration(_configuration);
     }

    private void ScanCoreModuleServices()
    {
        _log.Debug("Configuring core services");

        _module.Services.Scan(x => x.FromAssemblies(_module.ApplicationAssembly)
            .AddEndpointDefinitions());
    }

    private void RegisterModuleServices()
    {
        _log.Debug("Registering module services");

        _module.ConfigureServices();

        foreach (ServiceDescriptor service in _module.Services)
        {
            _hostServices.Add(service);
        }
    }
}
