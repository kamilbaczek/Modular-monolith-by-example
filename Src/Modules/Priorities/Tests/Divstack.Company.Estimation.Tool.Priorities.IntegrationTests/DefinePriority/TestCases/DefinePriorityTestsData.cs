namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority.TestCases;

using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal static class DefinePriorityTestsData
{
    public static object[] TestCases =
    {
        new object[]
        {
            new ValuationRequested(Guid.NewGuid(), Guid.NewGuid()),
            10
        }
    };
}
