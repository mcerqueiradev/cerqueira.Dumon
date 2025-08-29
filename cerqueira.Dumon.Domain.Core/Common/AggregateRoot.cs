using cerqueira.Dumon.Domain.Core.Abstractions;

namespace cerqueira.Dumon.Domain.Core.Common;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot() : base() { }

    protected AggregateRoot(Guid id) : base(id) { }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    // Método para aplicar eventos de domínio
    protected void ApplyDomainEvent(IDomainEvent domainEvent)
    {
        AddDomainEvent(domainEvent);
        // Aqui você pode adicionar lógica para aplicar o evento no estado do agregado
    }

    // Método para garantir que as invariantes do agregado são respeitadas
    protected virtual void CheckInvariants()
    {
        // Implementação específica em cada agregado
    }
}