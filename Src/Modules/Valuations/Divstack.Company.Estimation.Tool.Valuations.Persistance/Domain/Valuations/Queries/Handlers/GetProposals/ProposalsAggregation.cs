// ReSharper disable UnusedMember.Global
namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetProposals;

using Application.Valuations.Queries.GetProposalsById.Dtos;
using Marten.Events.Aggregation;
using Shared.DDD.BuildingBlocks;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalsAggregation : SingleStreamAggregation<ValuationProposalEntryDto>
{
    private const string NoDecision = "No decision";
    private const string Approved = "Approved";

    public void Apply(ProposalApprovedDomainEvent _, ValuationProposalEntryDto proposalEntryDto)
    {
        var currentDate = SystemTime.Now();
        proposalEntryDto.SetDecision(currentDate, Approved);
    }

    public ValuationProposalEntryDto Create(ProposalSuggestedDomainEvent suggestedDomainEvent)
    {
        var proposal = new ValuationProposalEntryDto(
            suggestedDomainEvent.Id,
            suggestedDomainEvent.ProposalId.Value,
            suggestedDomainEvent.Description.Message,
            suggestedDomainEvent.Price.Currency,
            suggestedDomainEvent.Price.Value!.Value,
            suggestedDomainEvent.OccurredOn,
            suggestedDomainEvent.SuggestedBy.Value,
            null,
            NoDecision
            );

        return proposal;
    }
}
