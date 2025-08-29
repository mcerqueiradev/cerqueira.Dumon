namespace cerqueira.Dumon.Domain.Core.Abstractions;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccurredOn { get; }
    string EventType { get; }
}
