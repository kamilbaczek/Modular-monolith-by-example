namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalApprovedDomainEvent : DomainEventBase
{
    public ProposalApprovedDomainEvent(
        ValuationId valuationId,
        ProposalId proposalId,
        EmployeeId suggestedBy,
        Money price)
    {
        ValuationId = valuationId;
        ProposalId = proposalId;
        SuggestedBy = suggestedBy;
        Price = price;
    }

    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
    public EmployeeId SuggestedBy { get; }
    public Money Price { get; }
}
