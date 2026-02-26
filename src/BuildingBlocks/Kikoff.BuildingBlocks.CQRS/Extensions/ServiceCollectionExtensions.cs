using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.CQRS.Dispatchers;
using Kikoff.BuildingBlocks.CQRS.Pipelines;
using Kikoff.BuildingBlocks.CQRS.Pipelines.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Kikoff.BuildingBlocks.CQRS.Extensions;

public static class ServiceCollectionExtensions
{
    internal const string CommonPipelineKey = "Common";

    extension(IServiceCollection services)
    {
        public IServiceCollection AddKikoffMessageDispatcher()
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

internal static class ServiceProviderExtensions
{
    extension(IServiceProvider serviceProvider)
    {
        internal ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>()
            where TCommand : ICommand<TResult>
        {
            ICommandHandler<TCommand, TResult>? handler = serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();

            return handler ?? throw new InvalidOperationException($"No handler found for command of type {typeof(TCommand).FullName}");
        }

        internal IRequestHandler<TRequest, TResult> GetRequestHandler<TRequest, TResult>()
            where TRequest : IRequest<TResult>
        {
            IRequestHandler<TRequest, TResult>? handler = serviceProvider.GetService<IRequestHandler<TRequest, TResult>>();

            return handler ?? throw new InvalidOperationException($"No handler found for request of type {typeof(TRequest).FullName}");
        }
    }
}

public static class ImplementationTypeSelectorExtensions
{
    extension(IImplementationTypeSelector selector)
    {
        public IImplementationTypeSelector AddCommandHandlers()
        {
            return selector
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithTransientLifetime();
        }
        public IImplementationTypeSelector AddRequestHandlers()
        {
            return selector
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithTransientLifetime();
        }
    }
}
