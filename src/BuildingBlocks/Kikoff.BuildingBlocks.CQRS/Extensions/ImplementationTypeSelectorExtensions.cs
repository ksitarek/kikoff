using Kikoff.BuildingBlocks.CQRS.Dispatchers;
using Kikoff.BuildingBlocks.CQRS.Pipelines;
using Kikoff.BuildingBlocks.CQRS.Pipelines.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.BuildingBlocks.CQRS.Extensions;

public static class ServiceCollectionExtensions
{
    internal const string CommonPipelineKey = "Common";

    extension(IServiceCollection services)
    {
        public IServiceCollection AddTalentFlowMessageDispatcher()
        {
            // Register default behaviors
            services.AddCommonPipeline(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddScoped<IDispatcher, InMemoryMessageDispatcher>();

            return services;
        }

        private IServiceCollection AddCommonPipeline(Type serviceType, Type implementationType)
        {
            services.AddKeyedTransient(serviceType, CommonPipelineKey, implementationType);
            return services;
        }

        public IServiceCollection AddModulePipeline(string moduleName, Type serviceType, Type implementationType)
        {
            services.AddKeyedTransient(serviceType, moduleName, implementationType);
            return services;
        }
    }
}
