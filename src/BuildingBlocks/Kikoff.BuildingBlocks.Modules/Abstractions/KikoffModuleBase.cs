using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.BuildingBlocks.Modules.Abstractions;

public abstract class KikoffModuleBase : IKikoffModule
{
    public abstract Assembly ApplicationAssembly { get; }

    public abstract Assembly InfrastructureAssembly { get; }

    public IConfiguration? Configuration { get; private set; }

    public IServiceCollection Services { get; } = new ServiceCollection();

    public string Name { get; }

    protected KikoffModuleBase()
    {
        Name = GetType().Name;
    }

    public void SetConfiguration(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public abstract void ConfigureServices();
}
