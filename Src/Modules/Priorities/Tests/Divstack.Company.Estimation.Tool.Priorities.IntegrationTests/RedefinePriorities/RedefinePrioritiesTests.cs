namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities;

using Assertions;
using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Common;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Shared.DDD.BuildingBlocks;
using TestCases;

public sealed class RedefinePrioritiesTests
{
    public RedefinePrioritiesTests() => SystemTime.SetDateTime(NowDate);
    
    private static readonly DateTime NowDate = new(2020, 2, 3, 1, 1, 1);
    private static readonly DateTime FutureDate = new(2020, 4, 3, 1, 1, 1);

    [Theory]
    [TestCaseSource(typeof(RedefinePriorityTestsData), nameof(RedefinePriorityTestsData.TestCases))]
    public async Task Given_RedefinePriorities_When_time_pass_Then_PrioritiesLevelWasIncreased(IList<ValuationRequested> valuationRequests)
    {
        var query = GetPrioritiesQuery.Create();
        await PrioritiesModuleTester.HandleValuationRequestedEventAsync(valuationRequests);
        var prioritiesBeforeTimePast = await PrioritiesModule.ExecuteQueryAsync(query);
        prioritiesBeforeTimePast.Should().HavePrioritiesInLowLevel(valuationRequests);
        SystemTime.SetDateTime(FutureDate);
        
        await PrioritiesModuleTester.RedefineAllAsync();

        var prioritiesAfterTimePass = await PrioritiesModule.ExecuteQueryAsync(query);
        prioritiesAfterTimePass.Should().HavePrioritiesInMediumLevel(valuationRequests);
    }
}
