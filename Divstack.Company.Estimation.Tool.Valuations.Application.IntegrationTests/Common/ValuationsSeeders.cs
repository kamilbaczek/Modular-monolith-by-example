using System;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common
{
    internal sealed class ValuationsSeeders
    {
        internal static async Task<Guid> CreateService()
        {
            using var scope = ValuationsTesting.CreateServiceScope;
            var category = await CreateCategory(scope);
            var service = await CreateService(scope, category);

            return service.Id;
        }

        private static async Task<ServiceDto> CreateService(IServiceScope scope, CategoryDto category)
        {
            var servicesService = scope.ServiceProvider.GetRequiredService<IServicesService>();
            var createServiceRequest = new CreateServiceRequest
            {
                Name = Lorem.GetFirstWord(),
                CategoryId = category.Id,
                Description = Lorem.Paragraphs(1).First(),
            };
            await servicesService.CreateAsync(createServiceRequest);
            var serviceDtos = await servicesService.GetAllAsync();
            var service = serviceDtos.Single(service => service.Name == createServiceRequest.Name);

            return service;
        }

        private static async Task<CategoryDto> CreateCategory(IServiceScope scope)
        {
            var categoriesService = scope.ServiceProvider.GetRequiredService<ICategoriesService>();

            var createCategoryRequest = new CreateCategoryRequest
            {
                Description = "test",
                Name = "Category 1"
            };
            await categoriesService.CreateAsync(createCategoryRequest);
            var categoryDtos = await categoriesService.GetAllAsync();
            var category = categoryDtos.Single(category => category.Name == createCategoryRequest.Name);

            return category;
        }
    }
}