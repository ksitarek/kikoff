using Serilog;

namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public abstract record MessageContext<TIn>
{
    public required Guid CorrelationId { get; set; }
    public required TIn Message { get; init; }
    public required string HandlerName { get; init; }
    public required ILogger Logger { get; init; }
    public required CancellationToken CancellationToken { get; init; }
}
