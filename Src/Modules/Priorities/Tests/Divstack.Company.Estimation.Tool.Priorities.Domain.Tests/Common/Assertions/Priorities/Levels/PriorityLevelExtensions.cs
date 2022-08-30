namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests.Common.Assertions.Priorities.Levels;

internal static class PriorityLevelExtensions
{
    internal static PriorityLevelAssertions Should(this PriorityLevel instance) => new(instance);
}
