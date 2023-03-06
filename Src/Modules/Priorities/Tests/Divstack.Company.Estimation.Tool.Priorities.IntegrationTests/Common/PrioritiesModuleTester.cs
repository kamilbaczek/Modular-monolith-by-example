namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common;

using Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Define;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Domain;
using Domain.Deadlines;

internal static class PrioritiesModuleTester
{
    internal static async Task HandleValuationRequestedEventAsync(IEnumerable<ValuationRequested> valuationRequests)
    {
        foreach (var valuationRequested in valuationRequests)
        {
            await HandleValuationRequestedEventAsync(valuationRequested);
        }
    }
    
    internal static async Task HandleValuationRequestedEventAsync(ValuationRequested valuationRequested)
    {
        using var scope = TestEngine.ServiceScopeFactory.CreateScope();
        var prioritiesRepository = scope.ServiceProvider.GetRequiredService<IPrioritiesRepository>();
        var deadlinesConfiguration = scope.ServiceProvider.GetRequiredService<IDeadlinesConfiguration>();
        var inquiriesModule = scope.ServiceProvider.GetRequiredService<IInquiriesModule>();

        var definePrioritiesEventHandler = new DefinePrioritiesEventHandler(prioritiesRepository, deadlinesConfiguration, inquiriesModule);
        await definePrioritiesEventHandler.Handle(valuationRequested, new TestableMessageHandlerContext());
    }
    
    internal static async Task RedefineAllAsync()
    {
        using var scope = TestEngine.ServiceScopeFactory.CreateScope();
        var prioritiesRedefiner = scope.ServiceProvider.GetRequiredService<IPrioritiesRedefiner>();
        await prioritiesRedefiner.RedefineAllAsync();
    }
}
