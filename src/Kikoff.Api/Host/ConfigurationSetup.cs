using System.Reflection;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.Json;

namespace Kikoff.Api.Host;

internal class ConfigurationSetup
{
    private readonly Assembly _assembly;
    private readonly WebApplicationBuilder _webApplicationBuilder;
    private readonly IConfigurationSource? _cliConfigurationSources;

    private IList<IConfigurationSource> Sources => _webApplicationBuilder.Configuration.Sources;

    private string EnvironmentName => _webApplicationBuilder.Environment.EnvironmentName;

    public ConfigurationSetup(
        Assembly assembly,
        WebApplicationBuilder webApplicationBuilder)
    {
        _assembly = assembly;
        _webApplicationBuilder = webApplicationBuilder;

        // Capture the CLI configuration source if it exists, so we can re-add it after clearing all sources.
        Type cliConfigSourceType = typeof(CommandLineConfigurationSource);
        _cliConfigurationSources = Sources.FirstOrDefault(x => x.GetType() == cliConfigSourceType);
    }

    public ConfigurationSetup ClearAllSources()
    {
        Sources.Clear();

        return this;
    }

    public ConfigurationSetup AddAppsettingsJson()
    {
        Sources.Add(new JsonConfigurationSource
        {
            Path = "appsettings.json",
            ReloadOnChange = true,
            Optional = false,
        });

        Sources.Add(new JsonConfigurationSource
        {
            Path = $"appsettings.{EnvironmentName}.json",
            ReloadOnChange = true,
            Optional = false,
        });

        return this;
    }

    public ConfigurationSetup AddUserSecrets()
    {
        if (_webApplicationBuilder.Environment.IsDevelopment())
        {
            _webApplicationBuilder.Configuration.AddUserSecrets(_assembly);
        }

        return this;
    }

    public ConfigurationSetup AddCliOverrides()
    {
        if (_cliConfigurationSources != null)
        {
            Sources.Add(_cliConfigurationSources);
        }

        return this;
    }
}
