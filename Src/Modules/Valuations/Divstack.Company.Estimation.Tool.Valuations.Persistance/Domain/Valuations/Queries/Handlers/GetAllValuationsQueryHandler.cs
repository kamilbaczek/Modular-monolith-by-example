namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.GetAll;
using MediatR;
using Tool.Valuations.Domain.Valuations;

internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: '$CompletedBy.Value', RequestedDate: 1, _id:0}";

    private readonly IValuationsNotificationsContext _valuationsNotificationsContext;
    public GetAllValuationsQueryHandler(IValuationsNotificationsContext valuationsNotificationsContext)
    {
        _valuationsNotificationsContext = valuationsNotificationsContext;
    }

    public async Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
    {
        var filterDefinition = FilterDefinition<Valuation>.Empty;
        var sortDefinition = Builders<Valuation>.Sort.Descending("RequestedDate");

        var valuationListItemDtos = await _valuationsNotificationsContext
            .Valuations
            .Find(filterDefinition)
            .Sort(sortDefinition)
            .Project<ValuationListItemDto>(ProjectionQuery)
            .ToListAsync(cancellationToken);

        return new ValuationListVm(valuationListItemDtos);
    }
}
