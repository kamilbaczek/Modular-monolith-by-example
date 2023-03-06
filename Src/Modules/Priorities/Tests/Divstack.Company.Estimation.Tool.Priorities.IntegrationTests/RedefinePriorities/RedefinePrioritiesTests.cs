namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.RedefinePriorities;

using Assertions;
using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Common;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Shared.DDD.BuildingBlocks;
using TestCases;

public sealed class RedefinePrioritiesTests
{
    private static readonly DateTime NowDate = new(2020, 2, 3, 1, 1, 1);
    private static DateTime FutureDate => NowDate.AddMonths(2);

    [Theory]
    [TestCaseSource(typeof(RedefinePriorityTestsData), nameof(RedefinePriorityTestsData.TestCases))]
    public async Task Given_RedefinePriorities_When_time_pass_Then_PrioritiesLevelWasIncreased(IEnumerable<ValuationRequested> valuationRequests)
    {
        var query = GetPrioritiesQuery.Create();
        SystemTime.SetDateTime(NowDate);
        await PrioritiesModuleTester.HandleValuationRequestedEventAsync(valuationRequests);
        var prioritiesBeforeTimePast = await PrioritiesModule.ExecuteQueryAsync(query);
        prioritiesBeforeTimePast.Should().HavePrioritiesInLowLevel();
        SystemTime.SetDateTime(FutureDate);
        
        await PrioritiesModuleTester.RedefineAllAsync();

        var prioritiesAfterTimePass = await PrioritiesModule.ExecuteQueryAsync(query);
        prioritiesAfterTimePass.Should().HavePrioritiesInMediumLevel();
    }
}
