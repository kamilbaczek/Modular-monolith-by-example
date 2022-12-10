namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using Assertions;
using Extensions;
using Fakers;

public class ServicesTests : ServicesTestsBase
{
    [Test]
    public async Task Given_Create_Then_NewServiceIsAvailable()
    {
        var categoryRequest = ServicesFaker.CreateCategory();
        var categoryId = await CategoriesService.CreateAsync(categoryRequest);
        var serviceRequest = ServicesFaker.CreateService(categoryId);

        var serviceId = await ServicesService.CreateAsync(serviceRequest);

        var services = await ServicesService.GetAllAsync();
        var createdService = services.GetService(serviceId);
        createdService.Should().BeService(serviceId, serviceRequest);
    }
    
    [Test]
    public async Task Given_Delete_When_ServiceExists_Then_ServiceIsDeleted()
    {
        var serviceId = await CreateFullService();
        await EnsureServiceExists(serviceId);

        await ServicesService.DeleteAsync(serviceId);
        
        await EnsureServiceDeleted(serviceId);
    }
}
