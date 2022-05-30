namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using Events;
using Exceptions;
using Proposals;
using Proposals.Events;

public sealed class Valuation : Entity, IAggregateRoot
{
    private Valuation() { }

    private Valuation(
        InquiryId inquiryId)
    {
        var valuationId = ValuationId.Create();
        var @event = new ValuationRequestedDomainEvent(valuationId, inquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public Guid Id { get; set; }
    public ValuationId ValuationId => ValuationId.Of(Id);
    private InquiryId InquiryId { get; set; }
    private LinkedList<Proposal> Proposals { get; set; }
    private ValuationStatus Status { get; set; }
    private DateTime RequestedDate { get; set; }
    private DateTime? CompletedDate { get; set; }
    private EmployeeId CompletedBy { get; set; }
    private IReadOnlyCollection<Proposal> NotCancelledProposals => GetNotCancelledProposals();

    private Proposal? ProposalWaitForDecision => NotCancelledProposals
        .SingleOrDefault(proposal => !proposal.HasDecision);

    public static Valuation Request(
        InquiryId inquiryId)
    {
        return new Valuation(inquiryId);
    }

    public void SuggestProposal(Money value,
        string description,
        EmployeeId proposedBy)
    {
        if (Status == ValuationStatus.Completed)
            throw new ValuationCompletedException(ValuationId);

        if (Status == ValuationStatus.WaitForClientDecision)
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision!.Id);

        var proposalDescription = ProposalDescription.From(description);
        var proposal = Proposal.Suggest(value, proposalDescription, proposedBy);

        var @event = new ProposalSuggestedDomainEvent(proposal, ValuationId, InquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void ApproveProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalApprovedDomainEvent(ValuationId, proposal);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void RejectProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalRejectedDomainEvent(
            ValuationId,
            proposal);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public void CancelProposal(ProposalId proposalId, EmployeeId employeeId)
    {
        var proposal = GetProposal(proposalId);
        var @event = new ProposalCancelledDomainEvent(InquiryId, ValuationId, proposal);
        AddDomainEvent(@event);
    }

    public void Complete(EmployeeId employeeId)
    {
        if (Status == ValuationStatus.Completed)
        {
            throw new ValuationCompletedException(ValuationId);
        }

        if (ProposalWaitForDecision is not null)
        {
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
        }

        if (!NotCancelledProposals.Any())
        {
            throw new CannotCompleteValuationWithNoProposalException(ValuationId);
        }

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
        @event.Proposal.Cancel(EmployeeId.Of(Guid.Empty));
        Status = ValuationStatus.WaitForProposal;
    }
    private void Apply(ProposalApprovedDomainEvent @event)
    {
        @event.Proposal.Approve();
        Status = ValuationStatus.Approved;
    }

    private void Apply(ProposalSuggestedDomainEvent @event)
    {
        Proposals.AddFirst(@event.Proposal);
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
        Proposals = new LinkedList<Proposal>();
        InquiryId = @event.InquiryId;
        Status = ValuationStatus.WaitForProposal;
    }

    private Proposal GetProposal(ProposalId proposalId)
    {
        var proposal = NotCancelledProposals.SingleOrDefault(proposal => proposal.Id == proposalId);
        if (proposal is null)
        {
            throw new ProposalNotFoundException(proposalId);
        }

        return proposal;
    }

    public void When(object @event)
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
    private IReadOnlyCollection<Proposal> GetNotCancelledProposals()
    {
        return Proposals
            .Where(proposal => !proposal.IsCancelled)
            .ToList();
    }
}
