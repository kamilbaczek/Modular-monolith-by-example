namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.Get;

using Application.Valuations.Queries.Get.Dtos;
using Common;
using Marten.Events.Aggregation;
using Tool.Valuations.Domain.Valuations.Events;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ValuationInformationAggregation : AggregateProjection<ValuationInformationDto>
{
    public void Apply(ProposalSuggestedDomainEvent @event, ValuationInformationDto informationDto)
    {
        informationDto.Status = ValuationStates.WaitForClientDecision;
    }

    public void Apply(ProposalApprovedDomainEvent @event, ValuationInformationDto informationDto)
    {
        informationDto.Status = ValuationStates.Approved;
    }

    public void Apply(ValuationCompletedDomainEvent @event, ValuationInformationDto informationDto)
    {
        informationDto.CompletedBy = @event.EmployeeId.Value;
    }

    public ValuationInformationDto Create(ValuationRequestedDomainEvent valuationRequested)
    {
        var valuationInformationDto = new ValuationInformationDto(
            valuationRequested.ValuationId.Value,
            ValuationStates.WaitForProposal,
            valuationRequested.InquiryId.Value,
            null,
            valuationRequested.OccurredOn);

        return valuationInformationDto;
    }
}
