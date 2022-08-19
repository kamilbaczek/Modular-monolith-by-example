namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using Assertions;
using Extensions;
using Fakers;
using NUnit.Framework;

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
}
