using Kikoff.BuildingBlocks.Http.Endpoints;
using Scrutor;

namespace Kikoff.BuildingBlocks.Modules.Extensions;

internal static class ImplementationTypeSelectorExtensions
{
    extension(IImplementationTypeSelector selector)
    {
        internal IImplementationTypeSelector AddEndpointDefinitions()
        {
            return selector
                .AddClasses(c => c.AssignableTo<IEndpointDefinition>(), publicOnly: false)
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        }
    }
}
