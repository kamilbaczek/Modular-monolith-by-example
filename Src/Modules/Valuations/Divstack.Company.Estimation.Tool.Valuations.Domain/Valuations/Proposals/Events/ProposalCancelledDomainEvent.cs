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
        ValuationId = valuationId;
        ProposalId = proposalId;
        CancelledBy = cancelledBy;
    }

    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
    public EmployeeId CancelledBy { get; }
}
