namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.States;

using Events;
using Proposals;
using Proposals.Events;

public sealed class ValuationApproved : Entity, IAggregateRoot, IValuationState
{
    private ValuationApproved() { }

    private ValuationApproved(
        ValuationId valuationId,
        InquiryId inquiryId,
        Proposal proposal)
    {
        InquiryId = inquiryId;
        Id = valuationId.Value;
        var @event = new ProposalApprovedDomainEvent(
            ValuationId, 
            proposal.Id,
            proposal.SuggestedBy, 
            proposal.Price);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public Guid Id { get; set; }
    private InquiryId InquiryId { get; set; }
    private ProposalId ProposalId { get; set; }
    private Money Price { get; set; }

    public ValuationId ValuationId => ValuationId.Of(Id);

    internal static ValuationApproved Create(ValuationId valuationId, InquiryId inquiryId, Proposal proposal) => 
        new(valuationId, inquiryId, proposal);

    public ValuationCompleted Complete(EmployeeId proposalId) => 
        ValuationCompleted.Create(InquiryId, proposalId, Price);

    private void Apply(ProposalApprovedDomainEvent @event)
    {
        ProposalId = @event.ProposalId;
        Price = @event.Price;
    }

    private void Apply(ValuationRequestedDomainEvent @event)
    {
        Id = @event.ValuationId.Value;
        InquiryId = @event.InquiryId;
    }

    internal void When(object @event)
    {
        switch (@event)
        {
            case ValuationRequestedDomainEvent valuationRequestedDomainEvent:
                Apply(valuationRequestedDomainEvent);
                break;
            case ProposalApprovedDomainEvent proposalApprovedDomainEvent:
                Apply(proposalApprovedDomainEvent);
                break;
        }
    }
}
