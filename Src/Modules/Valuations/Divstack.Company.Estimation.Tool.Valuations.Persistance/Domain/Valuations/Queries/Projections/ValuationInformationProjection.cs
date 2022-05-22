namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Projections;

using Application.Valuations.Queries.Get.Dtos;
using Marten.Events.Projections;
using Tool.Valuations.Domain.Valuations.Events;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

internal sealed class ValuationInformationProjection : EventProjection
{
    public ValuationInformationProjection()
    {
        Project<ValuationRequestedDomainEvent>((e, ops) =>
        {
            var valuationInformationDto = new ValuationInformationDto(e.ValuationId.Value, "waitforproposal", e.InquiryId.Value, null, e.OccurredOn);
            ops.Store(valuationInformationDto);
        });
        Project<ProposalSuggestedDomainEvent>(async (e, ops) =>
        {
            var informationDto = await ops.LoadAsync<ValuationInformationDto>(e.ValuationId.Value);
            informationDto.Status = "approved";

            ops.Store(informationDto);
        });
        Project<ProposalApprovedDomainEvent>(async (e, ops) =>
        {
            var informationDto = await ops.LoadAsync<ValuationInformationDto>(e.ValuationId.Value);
            informationDto.Status = "rejected";

            ops.Store(informationDto);
        });
        Project<ValuationCompletedDomainEvent>(async (e, ops) =>
        {
            var informationDto = await ops.LoadAsync<ValuationInformationDto>(e.ValuationId.Value);

            informationDto.Status = "completed";
            informationDto.CompletedBy = e.EmployeeId.Value;
            ops.Store(informationDto);
        });
    }
}
