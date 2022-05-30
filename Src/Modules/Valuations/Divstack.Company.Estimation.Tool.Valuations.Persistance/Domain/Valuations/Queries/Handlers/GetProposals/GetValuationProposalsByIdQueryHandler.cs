namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetProposals;

using Application.Valuations.Queries.GetProposalsById;
using Application.Valuations.Queries.GetProposalsById.Dtos;
using Marten;
using MediatR;

internal sealed class
    GetValuationProposalsByIdQueryHandler : IRequestHandler<GetValuationProposalsByIdQuery, ValuationProposalsVm>
{
    private readonly IDocumentStore _documentStore;
    public GetValuationProposalsByIdQueryHandler(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public async Task<ValuationProposalsVm> Handle(GetValuationProposalsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var valuations = await _documentStore
            .LightweightSession()
            .Query<ValuationProposalEntryDto>()
            .Where(proposalEntryDto => proposalEntryDto.Id == request.ValuationId)
            .ToListAsync(cancellationToken);
        var vm = new ValuationProposalsVm(valuations);

        return vm;
    }
}
