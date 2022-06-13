namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalCancelledDomainEvent : DomainEventBase
{
    public ProposalCancelledDomainEvent(
        InquiryId inquiryId,
        ValuationId valuationId,
        ProposalId proposalId,
        EmployeeId cancelledBy)
    {
        ValuationId = valuationId;
        ProposalId = proposalId;
        CancelledBy = cancelledBy;
    }

    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
    public EmployeeId CancelledBy { get; }
}
