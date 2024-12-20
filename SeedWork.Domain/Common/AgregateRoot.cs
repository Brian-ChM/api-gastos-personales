using SeedWork.Domain.Interfaces;

namespace SeedWork.Domain.Common;

public abstract class AgregateRoot<TId> : Entity<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected AgregateRoot() : base() { }

    protected virtual void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public virtual void ClearEvents()
    {
        _domainEvents.Clear();
    }
}
