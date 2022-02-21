namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds;

using Common.Contracts;
using Dtos;

public record GetPrioritiesByValuationsIdsQuery(IReadOnlyCollection<Guid> ValuationIds) : IQuery<PrioritiesListVm>
{
}
