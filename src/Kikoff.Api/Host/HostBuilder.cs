using Kikoff.BuildingBlocks.Modules;

namespace Kikoff.Api.Host;

internal class KikoffHostBuilder
{
    public IModule[] Modules { get; }

    public KikoffHostBuilder(params IModule[] modules)
    {
        Modules = modules;
    }
}
