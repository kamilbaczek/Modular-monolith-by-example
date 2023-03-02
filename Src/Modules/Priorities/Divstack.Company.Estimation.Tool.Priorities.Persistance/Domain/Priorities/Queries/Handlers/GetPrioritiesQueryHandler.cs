namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.Domain.Priorities.Queries.Handlers;

using Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;
using DataAccess;
using MediatR;
using MongoDB.Driver;
using Tool.Priorities.Domain;

internal sealed class GetPrioritiesQueryHandler : IRequestHandler<GetPrioritiesQuery, PrioritiesListVm>
{
    private const string ProjectionQuery =
        @"{ PriorityId: '$_id.Value', ValuationId: '$ValuationId.Value', InquiryId: '$InquiryId.Value', Level: '$Level.Name',_id:0, Archived: 1 }";

    private const string Archived = "Archived";
    private const string Level = "Level";

    private readonly IPrioritiesContext _prioritiesContext;

    public GetPrioritiesQueryHandler(IPrioritiesContext prioritiesContext) => 
        _prioritiesContext = prioritiesContext;

    public async Task<PrioritiesListVm> Handle(GetPrioritiesQuery request, CancellationToken cancellationToken)
    {
        var filter = Builders<Priority>.Filter.Eq(Archived, false);
        var sortDefinition = Builders<Priority>.Sort.Descending(Level);

        var priorityDtos = await _prioritiesContext
            .Priorities
            .Find(filter)
            .Sort(sortDefinition)
            .Project<PriorityDto>(ProjectionQuery)
            .ToListAsync(cancellationToken);

        return new PrioritiesListVm(priorityDtos);
    }
}
