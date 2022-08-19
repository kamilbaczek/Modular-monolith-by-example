namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using System.Collections.Generic;
using Common;
using Core.Services.Categories.Services;
using Core.Services.Dtos;
using Core.Services.Services;

public class ServicesTestsBase
{
    protected IServicesService _servicesService;
    protected ICategoriesService _categoriesService;
    protected ServicesTestsBase()
    {
        _servicesService = ServicesModule.GetServicesService();
        _categoriesService = ServicesModule.GetCategoriesService();
    }

    protected static ServiceDto GetServiceById(IReadOnlyCollection<ServiceDto> services, Guid serviceId) =>
        services.FirstOrDefault(serviceDto => serviceDto.Id == serviceId);
}
