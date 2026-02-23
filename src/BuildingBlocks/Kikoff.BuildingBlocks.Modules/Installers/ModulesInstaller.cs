using Kikoff.BuildingBlocks.Modules.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.BuildingBlocks.Modules.Installers;

public class ModulesInstaller
{
    private const string ModulesSectionName = "Modules";

    private readonly IKikoffModule[] _modules;
    private readonly IServiceCollection _hostServices;
    private readonly IConfigurationSection _modulesSection;

    public ModulesInstaller(IKikoffModule[] modules, IConfigurationRoot configurationRoot, IServiceCollection hostServices)
    {
        _modules = modules;
        _hostServices = hostServices;
        _modulesSection = configurationRoot.GetSection(ModulesSectionName);
    }

    public void InstallModules()
    {
        foreach (IKikoffModule module in _modules)
        {
            IConfigurationSection moduleConfigurationSection = GetModuleConfiguration(module);

            InstallModule(module, moduleConfigurationSection, _hostServices);
        }
    }

    private static void InstallModule(IKikoffModule module, IConfigurationSection configuration, IServiceCollection hostServices)
    {
        var installer = new ModuleInstaller(module, configuration, hostServices);

        installer.ConfigureModule();
        installer.ScanCoreModuleServices();
        installer.RegisterModuleServices();
    }

    private IConfigurationSection GetModuleConfiguration(IKikoffModule module)
    {
        return _modulesSection.GetSection($"{module.Name}");
    }
}
