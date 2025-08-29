using cerqueira.Dumon.Domain.Core.Abstractions;

namespace cerqueira.Dumon.Domain.Core.Common;

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime OccurredOn { get; }
    public string EventType => GetType().Name;

    protected DomainEvent()
    {
        EventId = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
