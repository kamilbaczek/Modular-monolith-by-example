namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using Common;
using Core.Services.Categories.Services;
using Core.Services.Services;
using Extensions;
using Fakers;

public class ServicesTestsBase
{
    protected readonly IServicesService ServicesService;
    protected readonly ICategoriesService CategoriesService;
    
    protected ServicesTestsBase()
    {
        ServicesService = ServicesModule.GetServicesService();
        CategoriesService = ServicesModule.GetCategoriesService();
    }

    protected async Task EnsureServiceDeleted(Guid serviceId)
    {
        var servicesAfterDelete = await ServicesService.GetAllAsync();
        servicesAfterDelete.GetService(serviceId).Should().BeNull();
    }
    
    protected async Task EnsureServiceExists(Guid serviceId)
    {
        var services = await ServicesService.GetAllAsync();
        services.GetService(serviceId).Should().NotBeNull();
    }

    protected async Task<Guid> CreateFullService()
    {
        var categoryId = await CreateCategory();
        var serviceId = await CreateService(categoryId);
        
        return serviceId;
    }

    private async Task<Guid> CreateService(Guid categoryId)
    {
        var serviceRequest = ServicesFaker.CreateService(categoryId);
        var serviceId = await ServicesService.CreateAsync(serviceRequest);
        
        return serviceId;
    }
    
    private async Task<Guid> CreateCategory()
    {
        var categoryRequest = ServicesFaker.CreateCategory();
        var categoryId = await CategoriesService.CreateAsync(categoryRequest);
        
        return categoryId;
    }
}
