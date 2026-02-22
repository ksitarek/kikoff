using Kikoff.BuildingBlocks.Modules;

namespace Kikoff.Api.Host;

public class KikoffHostBuilder
{
    public IModule[] Modules { get; }

    public KikoffHostBuilder(params IModule[] modules)
    {
        Modules = modules;
    }
}