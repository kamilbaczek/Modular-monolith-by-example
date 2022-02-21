namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.Domain.Priorities.Queries.Handlers;

using DataAccess;
using MediatR;
using Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds;
using Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal sealed class GetPrioritiesByValuationsIdsQueryHandler : IRequestHandler<GetPrioritiesByValuationsIdsQuery, PrioritiesListVm>
{
    private const string ProjectionQuery =
        @"{ PriorityId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: '$CompletedBy.Value', RequestedDate: 1, _id:0}";

    private readonly IPrioritiesContext _prioritiesContext;
    public GetPrioritiesByValuationsIdsQueryHandler(IPrioritiesContext prioritiesContext)
    {
        _prioritiesContext = prioritiesContext;
    }

    public Task<PrioritiesListVm> Handle(GetPrioritiesByValuationsIdsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
