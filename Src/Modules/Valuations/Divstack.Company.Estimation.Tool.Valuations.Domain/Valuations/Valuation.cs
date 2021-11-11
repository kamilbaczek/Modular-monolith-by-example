using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

public sealed class Valuation : Entity, IAggregateRoot
{
    private Valuation(
        Deadline deadline,
        InquiryId inquiryId)
    {
        Id = ValuationId.Create();
        RequestedDate = SystemTime.Now();
        Proposals = new List<Proposal>();
        History = new List<HistoricalEntry>();
        Deadline = deadline;
        InquiryId = inquiryId;
        ChangeStatus(ValuationStatus.WaitForProposal);
        AddDomainEvent(new ValuationRequestedDomainEvent(Id, InquiryId, Deadline));
    }

    public ValuationId Id { get; init; }
    private InquiryId InquiryId { get; }
    private IList<Proposal> Proposals { get; }
    private IList<HistoricalEntry> History { get; }
    private DateTime RequestedDate { get; }
    private DateTime? CompletedDate { get; set; }
    private EmployeeId CompletedBy { get; set; }
    private Deadline Deadline { get; }
    private IReadOnlyCollection<Proposal> NotCancelledProposals => GetNotCancelledProposals();

    private Proposal ProposalWaitForDecision => NotCancelledProposals
        .SingleOrDefault(proposal => !proposal.HasDecision);

    private HistoricalEntry RecentStatus => History.OrderBy(historicalEntry => historicalEntry.ChangeDate).Last();
    private bool IsWaitingForDecision => RecentStatus.Status == ValuationStatus.WaitForClientDecision;
    private bool IsCompleted => RecentStatus.Status == ValuationStatus.Completed;

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
            throw new ValuationCompletedException(Id);
        if (IsWaitingForDecision)
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);

        var proposalDescription = ProposalDescription.From(description);
        var proposal = Proposal.Suggest(value, proposalDescription, proposedBy);
        Proposals.Insert(0, proposal);
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
        AddDomainEvent(new ProposalCancelledDomainEvent(employeeId, proposalId, Id));
    }

    public void Complete(EmployeeId employeeId)
    {
        if (IsCompleted)
            throw new ValuationCompletedException(Id);
        if (ProposalWaitForDecision is not null)
            throw new ProposalWaitForDecisionException(ProposalWaitForDecision.Id);
        if (!NotCancelledProposals.Any())
            throw new CannotCompleteValuationWithNoProposalException(Id);
        CompletedBy = employeeId;
        CompletedDate = SystemTime.Now();
        ChangeStatus(ValuationStatus.Completed);
        AddDomainEvent(new ValuationCompletedDomainEvent(employeeId, Id));
    }

    private void ChangeStatus(ValuationStatus valuationStatus)
    {
        var historicalEntry = HistoricalEntry.Create(valuationStatus);
        History.Insert(0, historicalEntry);
    }

    private Proposal GetProposal(ProposalId proposalId)
    {
        var proposal = NotCancelledProposals.SingleOrDefault(proposal => proposal.Id == proposalId);
        if (proposal is null)
            throw new ProposalNotFoundException(proposalId);
        return proposal;
    }

    private IReadOnlyCollection<Proposal> GetNotCancelledProposals()
    {
        return Proposals
            .Where(proposal => !proposal.IsCancelled)
            .ToList();
    }
}
