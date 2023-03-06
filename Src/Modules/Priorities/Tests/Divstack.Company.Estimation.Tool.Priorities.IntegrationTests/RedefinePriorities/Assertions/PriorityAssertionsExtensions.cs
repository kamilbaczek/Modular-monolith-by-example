namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities.Assertions;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal static class PriorityAssertionsExtensions
{
    public static PriorityAssertions Should(this PrioritiesListVm priority)
    {
        return new PriorityAssertions(priority);
    }
}
