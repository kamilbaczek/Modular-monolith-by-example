namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Common.Engine.Mocks;

using Core.UserAccess;

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
}
