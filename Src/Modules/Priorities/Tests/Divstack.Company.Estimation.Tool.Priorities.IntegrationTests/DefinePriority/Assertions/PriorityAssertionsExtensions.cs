namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority.Assertions;

using Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal static class PriorityAssertionsExtensions 
{
    public static PriorityAssertions Should(this PriorityDto instance) => 
        new(instance);
}
