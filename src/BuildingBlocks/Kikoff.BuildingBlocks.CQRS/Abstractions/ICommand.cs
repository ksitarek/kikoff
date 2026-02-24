namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface ICommand;
public interface ICommand<TResult> : ICommand;
