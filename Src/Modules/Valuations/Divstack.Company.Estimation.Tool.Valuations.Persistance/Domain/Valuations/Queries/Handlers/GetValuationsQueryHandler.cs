using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MediatR;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";

    private readonly IValuationsContext _valuationsContext;

    public GetValuationsQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationVm> Handle(GetValuationQuery request, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(request.ValuationId);
        var valuationInformationDto = await _valuationsContext.Valuations
            .Find(valuation => valuation.Id == valuationId)
            .Project<ValuationInformationDto>(ProjectionQuery)
            .SingleOrDefaultAsync(cancellationToken);

        return new ValuationVm(valuationInformationDto);
    }
}
