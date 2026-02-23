using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.BuildingBlocks.Modules.Abstractions;

public interface IKikoffModule
{
    Assembly ApplicationAssembly { get; }
    Assembly InfrastructureAssembly { get; }
    string Name { get; }
    void SetConfiguration(IConfiguration configuration);
    void ConfigureServices();
    IServiceCollection Services { get; }
}
