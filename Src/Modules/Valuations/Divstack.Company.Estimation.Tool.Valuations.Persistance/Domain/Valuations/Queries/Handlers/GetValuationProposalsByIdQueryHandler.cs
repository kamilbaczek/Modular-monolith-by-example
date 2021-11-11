using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MediatR;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

internal sealed class
    GetValuationProposalsByIdQueryHandler : IRequestHandler<GetValuationProposalsByIdQuery, ValuationProposalsVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";

    private readonly IValuationsContext _valuationsContext;

    public GetValuationProposalsByIdQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationProposalsVm> Handle(GetValuationProposalsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(request.ValuationId);


        var valuationProposalsVm = await _valuationsContext.Valuations
            .Find(valuation => valuation.Id == valuationId)
            .Project<ValuationProposalsVm>(ProjectionQuery)
            .SingleOrDefaultAsync(cancellationToken);

        return valuationProposalsVm;
    }
}
