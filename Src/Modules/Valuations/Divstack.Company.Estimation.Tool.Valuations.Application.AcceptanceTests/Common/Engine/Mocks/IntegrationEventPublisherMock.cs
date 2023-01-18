namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Engine.Mocks;

using Application.Common.Interfaces;
using Moq;

internal static class IntegrationEventPublisherMock
{
    internal static void ReplaceIntegrationEventPublisher(this ServiceCollection services)
    {
        var descriptor = services.FirstOrDefault(serviceDescriptor =>
            serviceDescriptor.ServiceType == typeof(IIntegrationEventPublisher));
        services.Remove(descriptor!);
        services.AddTransient(_ =>
            Mock.Of<IIntegrationEventPublisher>());
    }
}
