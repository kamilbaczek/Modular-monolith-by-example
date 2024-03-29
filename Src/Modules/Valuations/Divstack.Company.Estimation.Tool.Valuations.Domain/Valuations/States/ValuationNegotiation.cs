﻿namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.States;

using Events;
using Exceptions;
using Proposals;
using Proposals.Events;
using Proposals.Extensions.Proposals;

public sealed class ValuationNegotiation : Entity, IAggregateRoot, IValuationState
{
    private const int Limit = 3;
    
    private ValuationNegotiation() { }

    private ValuationNegotiation(
        ValuationId valuationId,
        InquiryId inquiryId,
        ProposalDescription proposalDescription,
        Money price,
        EmployeeId employeeId)
    {
        Id = valuationId.Value;
        InquiryId = inquiryId;

        var proposalId = ProposalId.Create();
        var @event = new ProposalSuggestedDomainEvent(
            proposalId,
            price,
            proposalDescription,
            employeeId,
            ValuationId,
            InquiryId);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public Guid Id { get; set; }
    public ValuationId ValuationId => ValuationId.Of(Id);
    private InquiryId InquiryId { get; set; }
    private IList<Proposal> Proposals { get; } = new List<Proposal>();
    private IReadOnlyCollection<Proposal> NotCancelledProposals => Proposals.GetNotCancelled();

    private Proposal? ProposalWaitForDecision => NotCancelledProposals
        .GetWithNoDecision();
    
    internal static ValuationNegotiation Start(ValuationId valuationId, InquiryId inquiryId, ProposalDescription proposalDescription, Money price, EmployeeId employeeId) => 
        new(valuationId, inquiryId, proposalDescription, price, employeeId);
    
    public void ReSuggestProposal(
        Money price,
        string description,
        EmployeeId proposedBy)
    {
        if (ProposalWaitForDecision is not null)
            throw new ProposalWaitForClientDecisionException(ValuationId);

        if (Proposals.Count > Limit)
            throw new ValuationExceedLimitOfProposalsException(ValuationId, Limit);

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

    public ValuationApproved ApproveProposal(ProposalId proposalId)
    {
        var proposal = GetProposal(proposalId);

        return ValuationApproved.Create(
            ValuationId,
            InquiryId,
            proposal);
    }

    public void RejectProposal(ProposalId proposalId)
    {
        if (ProposalWaitForDecision is null)
            throw new ProposalHasAlreadyDecisionException(proposalId);
        
        var proposal = GetProposal(proposalId);
        var @event = new ProposalRejectedDomainEvent(
            ValuationId,
            proposalId,
            proposal.Price);
        Apply(@event);
        AddDomainEvent(@event);
    }
    
    private void Apply(ProposalSuggestedDomainEvent @event)
    {
        var proposal = Proposal.Suggest(
            @event.ProposalId,
            @event.Price,
            @event.Description,
            @event.SuggestedBy);
        Proposals.Add(proposal);
    }

    private void Apply(ValuationRequestedDomainEvent @event)
    {
        Id = @event.ValuationId.Value;
        InquiryId = @event.InquiryId;
    }

    private void Apply(ProposalRejectedDomainEvent @event)
    {
        var proposal = GetProposal(@event.ProposalId);
        proposal.Reject();
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
            case ProposalSuggestedDomainEvent suggestedDomainEvent:
                Apply(suggestedDomainEvent);
                break;
            case ProposalRejectedDomainEvent proposalRejectedDomainEvent:
                Apply(proposalRejectedDomainEvent);
                break;
            case ValuationRequestedDomainEvent valuationRequestedDomainEvent:
                Apply(valuationRequestedDomainEvent);
                break;
        }
    }
}
