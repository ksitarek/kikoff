namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface IMessageHandler<T, TResult>
{
    Task<TResult> HandleAsync(HandlerContext<T> handlerContext);
}
