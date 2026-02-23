namespace Kikoff.Modules.Sample.Application.Weather;

public interface IWeatherService
{
    Task<string> GetForecastAsync();
}
