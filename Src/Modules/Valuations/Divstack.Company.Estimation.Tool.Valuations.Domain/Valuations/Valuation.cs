namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using Deadlines;
using Events;
using Exceptions;
using History;
using Proposals;
using Proposals.Events;
using Shared.DDD.BuildingBlocks;
using Shared.DDD.ValueObjects;

public sealed class Valuation : Entity, IAggregateRoot
{
    public ValuationId Id { get; init; }
    private InquiryId InquiryId { get;  init;}
    private LinkedList<Proposal> Proposals { get;  init;}
    private LinkedList<HistoricalEntry> History { get;  init;}
    private DateTime RequestedDate { get;  init;}
    private DateTime? CompletedDate { get; set; }
    private EmployeeId CompletedBy { get; set; }
    private Deadline Deadline { get; init; }
    private IReadOnlyCollection<Proposal> NotCancelledProposals => GetNotCancelledProposals();

    private Proposal ProposalWaitForDecision => NotCancelledProposals
        .SingleOrDefault(proposal => !proposal.HasDecision);

    private HistoricalEntry RecentStatus => History.OrderBy(historicalEntry => historicalEntry.ChangeDate).Last();
    private bool IsWaitingForDecision => RecentStatus.Status == ValuationStatus.WaitForClientDecision;
    private bool IsCompleted => RecentStatus.Status == ValuationStatus.Completed;

    private Valuation(
        Deadline deadline,
        InquiryId inquiryId)
    {
        Id = ValuationId.Create();
        RequestedDate = SystemTime.Now();
        Proposals = new LinkedList<Proposal>();
        History = new LinkedList<HistoricalEntry>();
        Deadline = deadline;
        InquiryId = inquiryId;
        ChangeStatus(ValuationStatus.WaitForProposal);
        var @event = new ValuationRequestedDomainEvent(Id, InquiryId, Deadline);
        AddDomainEvent(@event);
    }
    
    public static Valuation Request(
        InquiryId inquiryId,
        Deadline deadline)
    {
        return new Valuation(deadline, inquiryId);
    }

    public void SuggestProposal(Money value,
        string description,
        EmployeeId proposedBy)
    {
        if (IsCompleted)
        {
            throw new ValuationCompletedException(Id);
        }

        if (IsWaitingForDecision)
        {
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
        }

        var proposalDescription = ProposalDescription.From(description);
        var proposal = Proposal.Suggest(value, proposalDescription, proposedBy);
        Proposals.AddFirst(proposal);
        ChangeStatus(ValuationStatus.WaitForClientDecision);

        var @event = new ProposalSuggestedDomainEvent(
            proposedBy,
            proposal.Id,
            value,
            proposalDescription,
            Id,
            InquiryId);
        AddDomainEvent(@event);
    }

    public void ApproveProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        proposal.Approve();
        ChangeStatus(ValuationStatus.Approved);

        var @event = new ProposalApprovedDomainEvent(
            Id,
            proposalId,
            proposal.Price,
            proposal.SuggestedBy);
        AddDomainEvent(@event);
    }

    public void RejectProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);
        proposal.Reject();
        ChangeStatus(ValuationStatus.Rejected);

        var @event = new ProposalRejectedDomainEvent(
            Id,
            proposalId,
            proposal.Price);
        AddDomainEvent(@event);
    }

    public void CancelProposal(ProposalId proposalId, EmployeeId employeeId)
    {
        var proposal = GetProposal(proposalId);
        proposal.Cancel(employeeId);
        ChangeStatus(ValuationStatus.WaitForProposal);

        var @event = new ProposalCancelledDomainEvent(employeeId, proposalId, Id);
        AddDomainEvent(@event);
    }

    public void Complete(EmployeeId employeeId)
    {
        if (IsCompleted)
        {
            throw new ValuationCompletedException(Id);
        }

        if (ProposalWaitForDecision is not null)
        {
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
        }

        if (!NotCancelledProposals.Any())
        {
            throw new CannotCompleteValuationWithNoProposalException(Id);
        }

        CompletedBy = employeeId;
        CompletedDate = SystemTime.Now();
        ChangeStatus(ValuationStatus.Completed);
        var recentProposal = Proposals.First();

        var @event = new ValuationCompletedDomainEvent(InquiryId, Id, recentProposal.Price);
        AddDomainEvent(@event);
    }

    private void ChangeStatus(ValuationStatus valuationStatus)
    {
        var historicalEntry = HistoricalEntry.Create(valuationStatus);
        History.AddFirst(historicalEntry);
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

    private IReadOnlyCollection<Proposal> GetNotCancelledProposals()
    {
        return Proposals
            .Where(proposal => !proposal.IsCancelled)
            .ToList();
    }
}
