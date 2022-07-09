// ReSharper disable UnusedMember.Global
namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetAll;

using Application.Valuations.Queries.GetAll;
using Common;
using Marten.Events.Aggregation;
using Tool.Valuations.Domain.Valuations.Events;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ValuationListItemAggregation : SingleStreamAggregation<ValuationListItemDto>
{
    public void Apply(ValuationCompletedDomainEvent @event, ValuationListItemDto listItemDto)
    {
        listItemDto.CompletedBy = @event.EmployeeId.Value;
        listItemDto.Status = ValuationStates.Completed;
    }

    public void Apply(ProposalSuggestedDomainEvent @event, ValuationListItemDto listItemDto)
    {
        listItemDto.Status = ValuationStates.WaitForClientDecision;
    }

    public void Apply(ProposalApprovedDomainEvent @event, ValuationListItemDto listItemDto)
    {
        listItemDto.Status = ValuationStates.Approved;
    }

    public ValuationListItemDto Create(ValuationRequestedDomainEvent valuationRequested)
    {
        var valuationInformationDto = new ValuationListItemDto(
            valuationRequested.ValuationId.Value,
            valuationRequested.InquiryId.Value,
            ValuationStates.WaitForProposal,
            valuationRequested.OccurredOn,
            null);

        return valuationInformationDto;
    }
}
