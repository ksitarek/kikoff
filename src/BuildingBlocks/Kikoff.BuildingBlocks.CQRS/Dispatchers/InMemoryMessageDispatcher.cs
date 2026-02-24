using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.CQRS.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Kikoff.BuildingBlocks.CQRS.Dispatchers;

internal class InMemoryMessageDispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryMessageDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchCommandAsync<TCommand, TResult>(TCommand command,
        CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
    {
        var correlationId = Guid.NewGuid();

        ILogger logger = Log.ForContext("CorrelationId", correlationId);

        logger.Information("Dispatching command {Command}", command.GetType().Name);

        ICommandHandler<TCommand, TResult> handler = GetCommandHandler<TCommand, TResult>(logger);

        Pipeline<TCommand, TResult> pipeline = PipelineBuilder<TCommand, TResult>.Create(_serviceProvider)
            .Build();

        var context = new CommandContext<TCommand>()
        {
            CorrelationId = correlationId,
            HandlerName = handler.GetType().FullName!,
            Message = command,
            Logger = logger,
            CancellationToken = cancellationToken
        };

        return await pipeline.ExecuteAsync(context, HandlerDelegate);

        async Task<TResult> HandlerDelegate() => await handler.HandleAsync(context);
    }

    private ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>(ILogger logger)
        where TCommand : ICommand<TResult>
    {
        ICommandHandler<TCommand, TResult>? handler = _serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();

        if (handler != null)
        {
            return handler;
        }

        logger.Error("No handler found for command {Command}", typeof(TCommand).Name);
        throw new InvalidOperationException($"No handler found for command of type {typeof(TCommand).FullName}");
    }
}
