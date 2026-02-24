using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.CQRS.Dispatchers;

public interface IDispatcher
{
    Task<TResult> DispatchCommandAsync<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResult>;

    Task<TResult> DispatchRequestAsync<TRequest, TResult>(
        TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResult>;
}
