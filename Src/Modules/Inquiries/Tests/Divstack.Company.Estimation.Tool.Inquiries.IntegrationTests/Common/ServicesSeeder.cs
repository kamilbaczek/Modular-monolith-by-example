namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationTests.Common;

using System;
using System.Threading.Tasks;
using Faker;
using Microsoft.Extensions.DependencyInjection;
using Services.Core.Services.Categories.Dtos;
using Services.Core.Services.Categories.Services;
using Services.Core.Services.Dtos;
using Services.Core.Services.Services;

public static class ServicesSeeder
{
    public static async Task<Guid> SeedAsync(string serviceName = "test Service",
        string categoryName = "test category")
    {
        var serviceScope = InquiriesTesting.CreateServiceScope;
        var category = await SeedCategory(serviceScope, categoryName);
        var serviceId = await SeedService(serviceScope, serviceName, category);

        return serviceId;
    }

    private static async Task<Guid> SeedService(IServiceScope serviceScope, string serviceName, Guid category)
    {
        var servicesService = serviceScope.ServiceProvider.GetRequiredService<IServicesService>();
        var createServiceRequest = new CreateServiceRequest
        {
            CategoryId = category, Description = Lorem.Sentence(), Name = serviceName
        };
        var serviceId = await servicesService.CreateAsync(createServiceRequest);

        return serviceId;
    }

    private static async Task<Guid> SeedCategory(IServiceScope serviceScope, string categoryName)
    {
        var categoriesService = serviceScope.ServiceProvider.GetRequiredService<ICategoriesService>();
        var createCategoryRequest = new CreateCategoryRequest
        {
            Description = categoryName, Name = Lorem.Sentence()
        };
        var category = await categoriesService.CreateAsync(createCategoryRequest);
        return category;
    }
}
