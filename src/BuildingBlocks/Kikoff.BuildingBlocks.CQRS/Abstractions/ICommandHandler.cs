namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface ICommandHandler<TCommand, TResult> : IMessageHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>;
