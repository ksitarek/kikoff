using Kikoff.BuildingBlocks.Http.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Kikoff.Modules.Sample.Application.Weather;

public class GetForecastEndpoint : IEndpointDefinition
{
    public void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/weather/forecast", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IWeatherService weatherService)
    {
        try
        {
            return Results.Ok(await weatherService.GetForecastAsync());
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }
}
