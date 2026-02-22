using Microsoft.AspNetCore.Builder;

namespace Kikoff.BuildingBlocks.Http.Cors;

public static class WebApplicationExtensions
{
    extension(WebApplication applicationBuilder)
    {
        public WebApplication UseKikoffCors()
        {
            applicationBuilder.UseCors(CorsOptionsConfig.PolicyName);
            return applicationBuilder;
        }
    }
}
