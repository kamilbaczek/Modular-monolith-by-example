namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities.TestCases;

using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal static class RedefinePriorityTestsData
{
    public static object[] TestCases =
    {
        new object[]
        {
            new List<ValuationRequested>
            {
                new(Guid.NewGuid(), Guid.NewGuid()),
                new(Guid.NewGuid(), Guid.NewGuid()),
                new(Guid.NewGuid(), Guid.NewGuid()),
                new(Guid.NewGuid(), Guid.NewGuid())
            }
        }
    };
}
