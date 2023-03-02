namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.GetPriorities;

using Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Common;
using Domain.Deadlines;
using Valuations.IntegrationsEvents.ExternalEvents;

public class DefinePriorityTests
{
    [Theory]
    public async Task Given_HandleValuationRequestedEvent_Then_PriorityIsDefined(ValuationRequested valuationRequested, int clientCompanySize, IDeadlinesConfiguration deadlinesConfiguration)
    {
        var valuationId = Guid.NewGuid();
        var inquiryId = Guid.NewGuid();
        var @event = new ValuationRequested(inquiryId, valuationId);
        
        await PrioritiesModuleTester.HandleValuationRequestedEvent(@event, clientCompanySize, deadlinesConfiguration);
        
        var query = GetPrioritiesQuery.Create();
        var result = await PrioritiesModule.ExecuteQueryAsync(query);
        var priority = result.Priorities.FirstOrDefault(priorityDto => priorityDto.ValuationId == valuationId);
        priority!.Level.Should().NotBeNullOrEmpty();
        priority.Archived.Should().BeFalse();
    }
}
