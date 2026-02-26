using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.CQRS.Extensions;
using Kikoff.BuildingBlocks.CQRS.Pipelines;

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
        ICommandHandler<TCommand, TResult> handler = _serviceProvider.GetCommandHandler<TCommand, TResult>();
        return await DispatchMessageAsync(command, handler, cancellationToken);
    }

    public async Task<TResult> DispatchRequestAsync<TRequest, TResult>(TRequest request,
        CancellationToken cancellationToken = default) where TRequest : IRequest<TResult>
    {
        IRequestHandler<TRequest, TResult> handler = _serviceProvider.GetRequestHandler<TRequest, TResult>();
        return await DispatchMessageAsync(request, handler, cancellationToken);
    }

    private async Task<TResult> DispatchMessageAsync<T, TResult>(
        T message,
        IMessageHandler<T, TResult> handler,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(message);

        var context = new HandlerContext<T>()
        {
            CorrelationId = Guid.NewGuid(),
            HandlerName = handler.GetType().FullName!,
            Message = message,
            CancellationToken = cancellationToken
        };

        context.Logger.Information("Dispatching message {T}", message.GetType().Name);

        Pipeline<T, TResult> pipeline = PipelineBuilder<T, TResult>.Create(_serviceProvider)
            .Build();

        return await pipeline.ExecuteAsync(context, HandlerDelegate);

        async Task<TResult> HandlerDelegate() => await handler.HandleAsync(context);
    }
}
