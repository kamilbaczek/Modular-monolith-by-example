namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Seeder.Services;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Services.Categories.Dtos;
using Core.Services.Categories.Services;
using Core.Services.Dtos;
using Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal sealed class ServicesSeeder : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServicesSeeder(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var categoriesService = scope.ServiceProvider.GetRequiredService<ICategoriesService>();
            var categories = await categoriesService.GetAllAsync(cancellationToken);
            if (categories.Any())
            {
                return;
            }

            var categoryDto = await CreateCategory(cancellationToken, categoriesService);

            var servicesService = scope.ServiceProvider.GetRequiredService<IServicesService>();
            var services = await servicesService.GetAllAsync(cancellationToken);
            if (services.Any())
            {
                return;
            }

            await CreateService(servicesService, categoryDto.Id);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static async Task CreateService(IServicesService servicesService, Guid categoryId)
    {
        var createService = new CreateServiceRequest
        {
            Name = "Cisco Router Fix", Description = "Very hard service", CategoryId = categoryId
        };
        await servicesService.CreateAsync(createService);
    }

    private static async Task<CategoryDto> CreateCategory(CancellationToken cancellationToken,
        ICategoriesService categoriesService)
    {
        var categoryRequest = new CreateCategoryRequest
        {
            Name = "Internet", Description = "Internet Services"
        };
        await categoriesService.CreateAsync(categoryRequest, cancellationToken);
        var categories = await categoriesService.GetAllAsync(cancellationToken);
        var categoryDto = categories.First();
        return categoryDto;
    }
}
