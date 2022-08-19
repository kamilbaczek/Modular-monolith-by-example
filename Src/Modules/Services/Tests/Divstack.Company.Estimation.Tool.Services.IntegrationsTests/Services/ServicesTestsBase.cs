namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using Common;
using Core.Services.Categories.Services;
using Core.Services.Services;

public class ServicesTestsBase
{
    protected readonly IServicesService ServicesService;
    protected readonly ICategoriesService CategoriesService;
    protected ServicesTestsBase()
    {
        ServicesService = ServicesModule.GetServicesService();
        CategoriesService = ServicesModule.GetCategoriesService();
    }
}
