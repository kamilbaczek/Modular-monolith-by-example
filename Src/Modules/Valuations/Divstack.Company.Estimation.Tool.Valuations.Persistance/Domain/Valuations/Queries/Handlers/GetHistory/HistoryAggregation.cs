namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetHistory;

using Application.Valuations.Queries.GetHistoryById.Dtos;
using Common;
using Marten.Events.Aggregation;
using Tool.Valuations.Domain.Valuations.Events;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class HistoryAggregation : AggregateProjection<ValuationHistoryDto>
{
    public void Apply(ValuationCompletedDomainEvent completed, ValuationHistoryDto valuationHistoryDto)
    {
        var historicalEntryDto = new ValuationHistoricalEntryDto(completed.Id, ValuationStates.Completed, completed.OccurredOn);
        valuationHistoryDto.AddEntry(historicalEntryDto);
    }

    public void Apply(ProposalSuggestedDomainEvent suggested, ValuationHistoryDto valuationHistoryDto)
    {
        var historicalEntryDto = new ValuationHistoricalEntryDto(suggested.Id, ValuationStates.WaitForClientDecision, suggested.OccurredOn);
        valuationHistoryDto.AddEntry(historicalEntryDto);
    }

    public ValuationHistoryDto Create(ValuationRequestedDomainEvent requested)
    {
        var historicalEntryDto = new ValuationHistoricalEntryDto(requested.Id, ValuationStates.WaitForProposal, requested.OccurredOn);
        var history = new ValuationHistoryDto(requested.Id);
        history.AddEntry(historicalEntryDto);

        return history;
    }
}
