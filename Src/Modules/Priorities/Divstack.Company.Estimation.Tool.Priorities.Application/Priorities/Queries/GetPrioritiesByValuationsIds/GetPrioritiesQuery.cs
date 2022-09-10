namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds;

using Common.Contracts;
using Dtos;

public record struct GetPrioritiesQuery : IQuery<PrioritiesListVm>
{
    public static GetPrioritiesQuery Create() => new();
}
