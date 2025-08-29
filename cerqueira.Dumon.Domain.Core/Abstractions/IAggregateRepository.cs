namespace cerqueira.Dumon.Domain.Core.Abstractions;

public interface IAggregateRepository<TAggregate, TId> : IRepository<TAggregate, TId>
    where TAggregate : class, IAggregateRoot
{
    Task<TAggregate> GetByIdWithEventsAsync(TId id, CancellationToken cancellationToken = default);
}
