namespace Common.Library.Core;

using MediatR;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<INotification>
{
    private readonly IList<INotification> _domainEvents = new List<INotification>();

    public IReadOnlyList<INotification> DomainEvents => _domainEvents.ToList();

    public void AddDomainEvent(INotification eventItem) => _domainEvents.Add(eventItem);

    public void ClearEvents() => _domainEvents.Clear();
}