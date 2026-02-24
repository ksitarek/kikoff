using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.CQRS.Pipelines;

internal class Pipeline<TMessage, TResult>
{
    private IEnumerable<IPipelineBehavior<TMessage, TResult>> Behaviors { get; }

    public Pipeline(IEnumerable<IPipelineBehavior<TMessage, TResult>> behaviors)
    {
        Behaviors = behaviors;
    }

    public async Task<TResult> ExecuteAsync(
        HandlerContext<TMessage> context,
        Func<Task<TResult>> handlerDelegate)
    {
        foreach (IPipelineBehavior<TMessage, TResult> behavior in Behaviors)
        {
            context.Logger.Debug("Executing pipeline behavior {Behavior} for handler {Handler}",
                behavior.GetType().FullName,
                context.HandlerName);

            Func<Task<TResult>> next = handlerDelegate;

            handlerDelegate = async () => await behavior.HandleAsync(context, next);
        }

        return await handlerDelegate();
    }
}
