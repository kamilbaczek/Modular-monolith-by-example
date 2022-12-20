namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.States;

using Events;
using Proposals;

public sealed class ValuationRequested : Entity, IAggregateRoot, IValuationState
{
    private ValuationRequested() { }
    
    public Guid Id { get; set; }
    private InquiryId InquiryId { get; set; }
    private DateTime RequestedAt { get; set; }
    public ValuationId ValuationId => ValuationId.Of(Id);

    public static ValuationRequested Request(InquiryId inquiryId) => 
        new(inquiryId);

    private ValuationRequested(
        InquiryId inquiryId)
    {
        var valuationId = ValuationId.Create();
        var @event = new ValuationRequestedDomainEvent(valuationId, inquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }
    
    public ValuationNegotiation SuggestProposal(
        Money price,
        string description,
        EmployeeId proposedBy)
    {
        var proposalDescription = ProposalDescription.From(description);
        return ValuationNegotiation.Start(
            ValuationId,
            InquiryId,
            proposalDescription,
            price,
            proposedBy);
    }

    private void Apply(ValuationRequestedDomainEvent @event)
    {
        Id = @event.ValuationId.Value;
        RequestedAt = SystemTime.Now();
        InquiryId = @event.InquiryId;
    }

    internal void When(object @event)
    {
        switch (@event)
        {
            case ValuationRequestedDomainEvent valuationRequestedDomainEvent:
                Apply(valuationRequestedDomainEvent);
                break;
        }
    }
}
