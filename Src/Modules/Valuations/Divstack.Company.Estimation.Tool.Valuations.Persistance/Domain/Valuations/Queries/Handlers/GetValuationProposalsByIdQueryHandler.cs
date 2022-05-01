namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.GetProposalsById;
using Application.Valuations.Queries.GetProposalsById.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tool.Valuations.Domain.Valuations;

internal sealed class
    GetValuationProposalsByIdQueryHandler : IRequestHandler<GetValuationProposalsByIdQuery, ValuationProposalsVm>
{
    private const string ProjectionQuery =
        @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value',CompletedBy: '$CompletedBy.Value', RequestedDate: 1, _id:0}";

    private readonly IValuationsContext _valuationsContext;

    public GetValuationProposalsByIdQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationProposalsVm> Handle([FromQuery] GetValuationProposalsByIdQuery request,
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
