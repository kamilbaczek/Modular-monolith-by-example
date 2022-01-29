namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalCancelledDomainEvent : DomainEventBase
{
    public ProposalCancelledDomainEvent(
        InquiryId inquiryId,
        ValuationId valuationId,
        ProposalId proposalId,
        EmployeeId cancelledBy)
    {
        InquiryId = inquiryId;
        CancelledBy = cancelledBy;
        ProposalId = proposalId;
        ValuationId = valuationId;
    }

    public InquiryId InquiryId { get; }
    public EmployeeId CancelledBy { get; }
    public ProposalId ProposalId { get; }
    public ValuationId ValuationId { get; }
}
