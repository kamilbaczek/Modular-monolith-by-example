namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority.Assertions;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal static class PrioritiesExtensions
{
    internal static PriorityDto? Get(this PrioritiesListVm listVm, Guid valuationId) => 
        listVm.Priorities.FirstOrDefault(priorityDto => priorityDto.ValuationId == valuationId);
}
