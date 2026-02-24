using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.CQRS.Pipelines.Behaviors;

public class LoggingBehavior<T, TResult> : IPipelineBehavior<T, TResult>
{
    public async Task<TResult> HandleAsync(HandlerContext<T> inputContext, Func<Task<TResult>> next)
    {
        string? messageName = typeof(T).FullName;

        try
        {
            inputContext.Logger.Debug("Handling {MessageType}", messageName);
            return await next();
        }
#pragma warning disable S2139
        //For some reason analyzer is not recognizing that exception is logged
        catch (Exception e)
        {
            inputContext.Logger.Error(e,
                "Error handling message of type {MessageType}",
                messageName);

            throw;
        }
#pragma warning restore S2139
    }
}
