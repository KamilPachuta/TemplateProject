namespace Domain.Shared;

public abstract class AggregateRoot : Entity
{
    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

    private readonly List<IDomainEvent> _domainEvents = new();
    
    protected void RaiseDomainEvent(IDomainEvent @domainEvent)
        => _domainEvents.Add(@domainEvent);
     

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected AggregateRoot()
    {
    }
    
    protected AggregateRoot(Guid id) : base(id)
    {
    }
}