using Microsoft.AspNetCore.Routing;

namespace Kikoff.BuildingBlocks.Http.Endpoints;

public interface IEndpointDefinition
{
    void Map(IEndpointRouteBuilder builder);
}
