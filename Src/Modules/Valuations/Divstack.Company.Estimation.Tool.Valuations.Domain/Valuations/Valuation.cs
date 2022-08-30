#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using Events;
using Exceptions;
using Extensions.Proposals;
using Proposals;
using Proposals.Events;

public sealed class Valuation : Entity, IAggregateRoot
{
    private Valuation() { }

    public Guid Id { get; set; }
    public ValuationId ValuationId => ValuationId.Of(Id);
    private InquiryId InquiryId { get; set; }
    private IList<Proposal> Proposals { get; set; }
    private ValuationStatus Status { get; set; }
    private DateTime RequestedDate { get; set; }
    private DateTime? CompletedDate { get; set; }
    private EmployeeId CompletedBy { get; set; }

    private IReadOnlyCollection<Proposal> NotCancelledProposals => Proposals.GetNotCancelled();
    private Proposal? ProposalWaitForDecision => NotCancelledProposals
        .GetWithNoDecision();
    private Valuation(
        InquiryId inquiryId)
    {
        var valuationId = ValuationId.Create();
        var @event = new ValuationRequestedDomainEvent(valuationId, inquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }


    public static Valuation Request(InquiryId inquiryId) => new(inquiryId);

    public void SuggestProposal(
        Money price,
        string description,
        EmployeeId proposedBy)
    {
        if (Status == ValuationStatus.Completed)
            throw new ValuationCompletedException(ValuationId);

        if (Status == ValuationStatus.WaitForClientDecision)
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision!.Id);

        var proposalId = ProposalId.Create();
        var proposalDescription = ProposalDescription.From(description);
        var @event = new ProposalSuggestedDomainEvent(
            proposalId,
            price,
            proposalDescription,
            proposedBy,
            ValuationId,
            InquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void ApproveProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalApprovedDomainEvent(ValuationId, proposalId, proposal.SuggestedBy, proposal.Price);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void RejectProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalRejectedDomainEvent(
            ValuationId,
            proposalId,
            proposal.Price);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void CancelProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalCancelledDomainEvent(InquiryId, ValuationId, proposalId, proposal.SuggestedBy);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void Complete(EmployeeId employeeId)
    {
        if (Status == ValuationStatus.Completed)
            throw new ValuationCompletedException(ValuationId);

        if (ProposalWaitForDecision is not null)
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);

        var anyProposal = NotCancelledProposals.Any();
        if (!anyProposal)
            throw new CannotCompleteValuationWithNoProposalException(ValuationId);

        var recentProposal = Proposals.First();
        var @event = new ValuationCompletedDomainEvent(InquiryId, ValuationId, employeeId, recentProposal.Price);
        Apply(@event);
        AddDomainEvent(@event);
    }

    private void Apply(ValuationCompletedDomainEvent @event)
    {
        CompletedBy = @event.EmployeeId;
        CompletedDate = @event.OccurredOn;
        Status = ValuationStatus.Completed;
    }

    private void Apply(ProposalCancelledDomainEvent @event)
    {
        var proposal = GetProposal(@event.ProposalId);
        var employeeId = @event.CancelledBy;
        proposal.Cancel(employeeId);
        Status = ValuationStatus.WaitForProposal;
    }
    private void Apply(ProposalApprovedDomainEvent @event)
    {
        var proposal = GetProposal(@event.ProposalId);
        proposal.Approve();
        Status = ValuationStatus.Approved;
    }

    private void Apply(ProposalSuggestedDomainEvent @event)
    {
        var proposal = Proposal.Suggest(
                        @event.ProposalId,
                        @event.Price,
                        @event.Description,
                        @event.SuggestedBy);
        Proposals.Add(proposal);
        Status = ValuationStatus.WaitForClientDecision;
    }

    private void Apply(ProposalRejectedDomainEvent @event)
    {
        var proposal = GetProposal(@event.ProposalId);
        proposal.Reject();
        Status = ValuationStatus.Rejected;
    }

    private void Apply(ValuationRequestedDomainEvent @event)
    {
        Id = @event.ValuationId.Value;
        RequestedDate = SystemTime.Now();
        Proposals = Enumerable.Empty<Proposal>().ToList();
        InquiryId = @event.InquiryId;
        Status = ValuationStatus.WaitForProposal;
    }

    private Proposal GetProposal(ProposalId proposalId)
    {
        var proposal = NotCancelledProposals.Get(proposalId);
        if (proposal is null)
            throw new ProposalNotFoundException(proposalId);

        return proposal;
    }

    internal void When(object @event)
    {
        switch (@event)
        {
            case ValuationRequestedDomainEvent valuationRequestedDomainEvent:
                Apply(valuationRequestedDomainEvent);
                break;
            case ProposalSuggestedDomainEvent suggestedDomainEvent:
                Apply(suggestedDomainEvent);
                break;
            case ProposalRejectedDomainEvent proposalRejectedDomainEvent:
                Apply(proposalRejectedDomainEvent);
                break;
            case ProposalCancelledDomainEvent proposalCancelledDomainEvent:
                Apply(proposalCancelledDomainEvent);
                break;
            case ProposalApprovedDomainEvent proposalApprovedDomainEvent:
                Apply(proposalApprovedDomainEvent);
                break;
            case ValuationCompletedDomainEvent valuationCompletedDomainEvent:
                Apply(valuationCompletedDomainEvent);
                break;
        }
    }
}
