using Kikoff.BuildingBlocks.CQRS.Pipelines;

namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(CommandContext<TCommand> command);
}
