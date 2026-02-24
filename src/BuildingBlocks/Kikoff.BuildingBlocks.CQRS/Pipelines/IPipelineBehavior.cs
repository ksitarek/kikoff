using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.CQRS.Pipelines;

public interface IPipelineBehavior<TInput, TOutput>
{
    Task<TOutput> HandleAsync(MessageContext<TInput> inputContext, Func<Task<TOutput>> next);
}
