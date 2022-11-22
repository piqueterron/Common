namespace Common.Library.Core;

public interface IAggregateRoot<TDomainEvent>
    where TDomainEvent : notnull
{
    IReadOnlyList<TDomainEvent> DomainEvents { get; }

    void AddDomainEvent(TDomainEvent eventItem);

    void ClearEvents();
}