using System.Reflection;
using Kikoff.BuildingBlocks.Modules.Abstractions;
using Kikoff.Modules.Sample.Application;
using Kikoff.Modules.Sample.Application.Weather;
using Kikoff.Modules.Sample.Infrastructure.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.Modules.Sample.Infrastructure;

public sealed class SampleKikoffModule : KikoffModuleBase
{
    public override Assembly ApplicationAssembly => SampleApplication.Assembly;

    public override Assembly InfrastructureAssembly => SampleInfrastructure.Assembly;

    public override void ConfigureServices()
    {
        Services.AddScoped<IWeatherService, SampleWeatherService>();
    }
}
