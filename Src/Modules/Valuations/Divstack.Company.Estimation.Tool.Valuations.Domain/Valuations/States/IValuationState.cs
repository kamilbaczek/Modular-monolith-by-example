namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.States;

public interface IValuationState
{
    ValuationId ValuationId { get; }
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
}
