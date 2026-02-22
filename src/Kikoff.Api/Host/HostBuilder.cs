using Kikoff.BuildingBlocks.Modules;

namespace Kikoff.Api.Host;

public class KikoffHostBuilder
{
    private readonly List<IModule> _modules = new();

    public KikoffHostBuilder AddModule(IModule module)
    {
        _modules.Add(module);
        return this;
    }
}