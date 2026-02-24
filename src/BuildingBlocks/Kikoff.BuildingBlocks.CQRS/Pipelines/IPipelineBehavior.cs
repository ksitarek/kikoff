using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.CQRS.Pipelines;

public interface IPipelineBehavior<TInput, TOutput>
{
    Task<TOutput> HandleAsync(HandlerContext<TInput> inputContext, Func<Task<TOutput>> next);
}
