using Kikoff.BuildingBlocks.CQRS.Abstractions;

namespace Kikoff.BuildingBlocks.Domain.Abstractions;

public abstract class DomainEvent : INotification
{
    public Guid EventId { get; }
    public DateTime OccurredOnUtc { get; }

    protected DomainEvent()
    {
        EventId = Guid.NewGuid();
        OccurredOnUtc = DateTime.UtcNow;
    }
}