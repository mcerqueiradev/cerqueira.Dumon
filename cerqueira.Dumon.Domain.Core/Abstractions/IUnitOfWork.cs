namespace cerqueira.Dumon.Domain.Core.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    IRepository<TEntity, TId> GetRepository<TEntity, TId>() where TEntity : class;
    IAggregateRepository<TAggregate, TId> GetAggregateRepository<TAggregate, TId>()
        where TAggregate : class, IAggregateRoot;
}
