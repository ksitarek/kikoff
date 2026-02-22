namespace Kikoff.BuildingBlocks.Http.Cors;

public sealed class CorsOptionsConfig
{
    public const string PolicyName = "DefaultCorsPolicy";

    public string[] AllowedOrigins { get; init; } = Array.Empty<string>();
    public string[] AllowedMethods { get; init; } = Array.Empty<string>();
    public string[] AllowedHeaders { get; init; } = Array.Empty<string>();
    public bool AllowCredentials { get; init; }
}
