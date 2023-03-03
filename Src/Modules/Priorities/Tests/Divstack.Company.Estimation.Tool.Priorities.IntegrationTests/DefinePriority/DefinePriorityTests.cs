namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority;

using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common;
using Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.DefinePriority.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using TestCases;

public sealed class DefinePriorityTests
{
    [Theory]
    [TestCaseSource(typeof(DefinePriorityTestsData), nameof(DefinePriorityTestsData.TestCases))]
    public async Task Given_HandleValuationRequestedEvent_Then_PriorityIsDefined(ValuationRequested valuationRequested, int clientCompanySize)
    {
        await PrioritiesModuleTester.HandleValuationRequestedEvent(valuationRequested, clientCompanySize);
        
        var query = GetPrioritiesQuery.Create();
        var result = await PrioritiesModule.ExecuteQueryAsync(query);
        var priority = result.Get(valuationRequested.ValuationId);
        priority!.Should().ShouldBeCorrect(valuationRequested);
    }
}
