using Serilog;

namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public record HandlerContext<TIn>
{
    public required Guid CorrelationId { get; set; }
    public required TIn Message { get; init; }
    public required string HandlerName { get; init; }
    public ILogger Logger { get; init; }
    public required CancellationToken CancellationToken { get; init; }

    public HandlerContext()
    {
        Logger = Log.ForContext("CorrelationId", CorrelationId);
    }
}
