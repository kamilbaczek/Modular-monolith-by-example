namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.Get;
using Application.Valuations.Queries.Get.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tool.Valuations.Domain.Valuations;

internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy:'$CompletedBy.Value', RequestedDate: 1, _id:0}";

    private readonly IValuationsContext _valuationsContext;

    public GetValuationsQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationVm> Handle([FromQuery] GetValuationQuery request, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(request.ValuationId);
        var valuationInformationDto = await _valuationsContext.Valuations
            .Find(valuation => valuation.ValuationId == valuationId)
            .Project<ValuationInformationDto>(ProjectionQuery)
            .SingleOrDefaultAsync(cancellationToken);

        return new ValuationVm(valuationInformationDto);
    }
}
