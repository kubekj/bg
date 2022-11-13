namespace Domain.Primitives;

public class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    public AggregateRoot(Guid id) : base(id)
    {
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}