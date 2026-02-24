using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.Modules.Extensions;
using ServiceCollectionExtensions = Kikoff.BuildingBlocks.CQRS.Extensions.ServiceCollectionExtensions;

namespace Kikoff.BuildingBlocks.CQRS.Dispatchers;

public interface IDispatcher
{
    Task<TResult> DispatchCommandAsync<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResult>;
}
