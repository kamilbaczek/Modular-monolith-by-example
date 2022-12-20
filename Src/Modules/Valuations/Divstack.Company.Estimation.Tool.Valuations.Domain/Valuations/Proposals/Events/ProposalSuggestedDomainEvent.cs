namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

using States;

public sealed class ProposalSuggestedDomainEvent : DomainEventBase
{
    public ProposalSuggestedDomainEvent(
        ProposalId proposalId,
        Money price,
        ProposalDescription description,
        EmployeeId suggestedBy,
        ValuationId valuationId,
        InquiryId inquiryId)
    {
        ProposalId = proposalId;
        Price = price;
        Description = description;
        SuggestedBy = suggestedBy;
        ValuationId = valuationId;
        InquiryId = inquiryId;
    }
    public ProposalId ProposalId { get; }
    public Money Price { get; }
    public ProposalDescription Description { get; }
    public EmployeeId SuggestedBy { get; }
    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
}
