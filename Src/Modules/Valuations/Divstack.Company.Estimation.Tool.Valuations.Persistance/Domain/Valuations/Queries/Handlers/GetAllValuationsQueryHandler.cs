namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using System.Threading;
using System.Threading.Tasks;
using Application.Valuations.Queries.GetAll;
using DataAccess;
using MediatR;
using MongoDB.Driver;
using Tool.Valuations.Domain.Valuations;

internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: '$CompletedBy.Value', RequestedDate: 1, _id:0}";

    private readonly IValuationsContext _valuationsContext;

    public GetAllValuationsQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
    {
        var filterDefinition = FilterDefinition<Valuation>.Empty;
        var valuationListItemDtos = await _valuationsContext.Valuations
            .Find(filterDefinition)
            .Project<ValuationListItemDto>(ProjectionQuery)
            .ToListAsync(cancellationToken);

        return new ValuationListVm(valuationListItemDtos);
    }
}
