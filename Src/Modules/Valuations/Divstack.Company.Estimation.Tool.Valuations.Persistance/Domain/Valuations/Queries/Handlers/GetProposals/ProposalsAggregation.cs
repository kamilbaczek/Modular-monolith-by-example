namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetProposals;

using Application.Valuations.Queries.GetProposalsById.Dtos;
using Marten.Events.Aggregation;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

[Obsolete]
public class ProposalsAggregation : AggregateProjection<ValuationProposalEntryDto>
{
    public void Apply(ProposalApprovedDomainEvent @event, ValuationProposalEntryDto proposalEntryDto)
    {
        proposalEntryDto = proposalEntryDto with
        {
            Decision = "Approved",
            DecisionDate = @event.OccurredOn
        };
    }

    public ValuationProposalEntryDto Create(ProposalSuggestedDomainEvent suggestedDomainEvent)
    {
        var proposal = new ValuationProposalEntryDto(
            suggestedDomainEvent.Id,
            suggestedDomainEvent.Proposal.Id.Value,
            suggestedDomainEvent.Proposal.Description.Message,
            suggestedDomainEvent.Proposal.Price.Currency,
            suggestedDomainEvent.Proposal.Price.Value.Value,
            suggestedDomainEvent.OccurredOn,
            suggestedDomainEvent.Proposal.SuggestedBy.Value,
            null,
            "No decision");

        return proposal;
    }
}
