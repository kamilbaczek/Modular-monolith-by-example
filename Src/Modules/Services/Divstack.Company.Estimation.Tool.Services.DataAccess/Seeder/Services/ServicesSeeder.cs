namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Seeder.Services;

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
        using var scope = _serviceScopeFactory.CreateScope();
        var categoriesService = scope.ServiceProvider.GetRequiredService<ICategoriesService>();
        var categories = await categoriesService.GetAllAsync(cancellationToken);
        if (!categories.Any())
        {
            var categoryDto = await CreateCategoryAsync(categoriesService, cancellationToken);
            categories.Add(categoryDto);
        }

        var category = categories.First();
        var servicesService = scope.ServiceProvider.GetRequiredService<IServicesService>();
        var services = await servicesService.GetAllAsync(cancellationToken);
        if (!services.Any())
        {
            await CreateServiceAsync(servicesService, category.Id);
        }

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static async Task CreateServiceAsync(IServicesService servicesService, Guid categoryId)
    {
        var createService = new CreateServiceRequest(categoryId, "Cisco Router Fix", "Very hard service");
        await servicesService.CreateAsync(createService);
    }

    private static async Task<CategoryDto> CreateCategoryAsync(ICategoriesService categoriesService, CancellationToken cancellationToken)
    {
        var categoryRequest = new CreateCategoryRequest("Internet", "Internet Services");
        await categoriesService.CreateAsync(categoryRequest, cancellationToken);
        var categories = await categoriesService.GetAllAsync(cancellationToken);
        var categoryDto = categories.First();
        
        return categoryDto;
    }
}
