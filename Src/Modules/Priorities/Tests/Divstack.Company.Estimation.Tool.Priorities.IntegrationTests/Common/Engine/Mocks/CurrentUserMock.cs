namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common.Engine.Mocks;

using Domain.UserAccess;
using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;

internal static class CurrentUserMock
{
    internal static Guid CurrentUserId => Guid.Parse("33268e45-6a7e-4028-9247-b950c99ee755");

    internal static void ReplaceCurrentUserService(this IServiceCollection services)
    {
        var currentUserServiceDescriptor = services.FirstOrDefault(serviceDescriptor =>
            serviceDescriptor.ServiceType == typeof(ICurrentUserService));
        services.Remove(currentUserServiceDescriptor!);
        services.AddTransient(_ =>
            Mock.Of<ICurrentUserService>(
                currentUserService => currentUserService.GetPublicUserId() == CurrentUserId));
    }
    
    internal static void MockInquiriesModule(this IServiceCollection services)
    {
        var inquiriesModule = new Mock<IInquiriesModule>();
        var clientCompanySize = 10;
        SetupGetInquiryClientQuery(inquiriesModule, clientCompanySize);
        services.AddTransient<IInquiriesModule>(_ => inquiriesModule.Object);
    }
    
    private static void SetupGetInquiryClientQuery(Mock<IInquiriesModule> inquiriesModule, int clientCompanySize)
    {
        var query = new InquiryClientDto("John", "Doe", "test@mail.com", "123456789", clientCompanySize.ToString());
        inquiriesModule
            .Setup(module => module.ExecuteQueryAsync(It.IsAny<GetInquiryClientQuery>()))
            .ReturnsAsync(query);
    }
}
