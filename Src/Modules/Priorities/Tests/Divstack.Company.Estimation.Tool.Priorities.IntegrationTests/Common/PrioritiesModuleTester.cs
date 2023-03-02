namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common;

using Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Define;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Domain;
using Domain.Deadlines;

internal static class PrioritiesModuleTester
{
    internal static async Task HandleValuationRequestedEvent(ValuationRequested valuationRequested, int clientCompanySize, IDeadlinesConfiguration deadlinesConfiguration)
    {
        using var scope = TestEngine.ServiceScopeFactory.CreateScope();
        var prioritiesRepository = scope.ServiceProvider.GetRequiredService<IPrioritiesRepository>();

        var inquiriesModule = new Mock<IInquiriesModule>();
        SetupGetInquiryClientQuery(inquiriesModule, clientCompanySize);
        
        var definePrioritiesEventHandler = new DefinePrioritiesEventHandler(prioritiesRepository, deadlinesConfiguration, inquiriesModule.Object);
        await definePrioritiesEventHandler.Handle(valuationRequested, new TestableMessageHandlerContext());
    }
    
    private static void SetupGetInquiryClientQuery(Mock<IInquiriesModule> inquiriesModule, int clientCompanySize)
    {
        var query = new InquiryClientDto("John", "Doe", "test@mail.com", "123456789", clientCompanySize.ToString());
        inquiriesModule
            .Setup(module => module.ExecuteQueryAsync(It.IsAny<GetInquiryClientQuery>()))
            .ReturnsAsync(query);
    }
}
