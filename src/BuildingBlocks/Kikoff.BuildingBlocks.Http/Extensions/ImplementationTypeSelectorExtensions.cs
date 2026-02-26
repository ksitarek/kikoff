using Kikoff.BuildingBlocks.Http.Endpoints;
using Scrutor;

namespace Kikoff.BuildingBlocks.Http.Extensions;

public static class ImplementationTypeSelectorExtensions
{
    extension(IImplementationTypeSelector selector)
    {
        public IImplementationTypeSelector AddEndpointDefinitions()
        {
            return selector
                .AddClasses(c => c.AssignableTo<IEndpointDefinition>(), publicOnly: false)
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        }

    }
}
