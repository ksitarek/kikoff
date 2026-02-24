namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface IRequestHandler<TRequest, TResult> : IMessageHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>, IRequest;
