namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Common;

using Core.Services.Categories.Services;
using Core.Services.Services;

internal static class ServicesModule
{
    internal static IServicesService GetServicesService()
    {
        using var scope = TestEngine.ServiceScopeFactory!.CreateScope();
        var servicesService = scope.ServiceProvider.GetRequiredService<IServicesService>();

        return servicesService;
    }

    internal static ICategoriesService GetCategoriesService()
    {
        using var scope = TestEngine.ServiceScopeFactory!.CreateScope();
        var categoriesService = scope.ServiceProvider.GetRequiredService<ICategoriesService>();

        return categoriesService;
    }
}
