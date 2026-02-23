using Kikoff.Modules.Sample.Application.Weather;

namespace Kikoff.Modules.Sample.Infrastructure.Weather;

internal class SampleWeatherService : IWeatherService
{
    public Task<string> GetForecastAsync()
    {
        return Task.FromResult("Sample Weather Service");
    }
}
