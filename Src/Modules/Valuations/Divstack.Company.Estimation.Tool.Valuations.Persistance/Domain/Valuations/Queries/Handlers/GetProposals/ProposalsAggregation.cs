namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetProposals;

using Application.Valuations.Queries.GetProposalsById.Dtos;
using Marten.Events.Aggregation;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

internal sealed class ProposalsAggregation : SingleStreamAggregation<ValuationProposalEntryDto>
{
    private const string NoDecision = "No decision";
    private const string Approved = "Approved";
    public void Apply(ProposalApprovedDomainEvent @event, ValuationProposalEntryDto proposalEntryDto)
    {
        proposalEntryDto = proposalEntryDto with
        {
            Decision = Approved,
            DecisionDate = @event.OccurredOn
        };
    }

    public ValuationProposalEntryDto Create(ProposalSuggestedDomainEvent suggestedDomainEvent)
    {
        var proposal = new ValuationProposalEntryDto(
            suggestedDomainEvent.Id,
            suggestedDomainEvent.Id,
            suggestedDomainEvent.Description.Message,
            suggestedDomainEvent.Price.Currency,
            suggestedDomainEvent.Price.Value.Value,
            suggestedDomainEvent.OccurredOn,
            suggestedDomainEvent.SuggestedBy.Value,
            null,
            NoDecision
            );

        return proposal;
    }
}
