namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public sealed record CommandContext<TCommand> : MessageContext<TCommand>
    where TCommand : ICommand;
