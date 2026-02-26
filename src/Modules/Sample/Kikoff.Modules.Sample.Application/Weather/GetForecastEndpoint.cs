using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.CQRS.Dispatchers;
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

    private static async Task<IResult> HandleAsync(IDispatcher dispatcher, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await dispatcher.DispatchRequestAsync<GetWeatherForecastRequest, string>(new(), cancellationToken));
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }
}

internal record GetWeatherForecastRequest : IRequest<string>;

internal class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, string>
{
    private readonly IWeatherService _weatherService;

    public GetWeatherForecastHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    public Task<string> HandleAsync(HandlerContext<GetWeatherForecastRequest> handlerContext)
    {
        return _weatherService.GetForecastAsync();
    }
}
