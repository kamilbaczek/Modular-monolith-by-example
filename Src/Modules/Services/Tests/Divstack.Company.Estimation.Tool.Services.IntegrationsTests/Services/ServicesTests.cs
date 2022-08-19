namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services;

using Core.Services.Attributes.Dtos;
using Fakers;
using NUnit.Framework;

public class ServicesTests : ServicesTestsBase
{
    [Test]
    public async Task Given_Create_Then_NewServiceIsAvailableOnServicesList()
    {
        var categoryRequest = ServicesFaker.CreateCategory();
        var categoryId = await _categoriesService.CreateAsync(categoryRequest);
        var serviceRequest = ServicesFaker.CreateService(categoryId);

        var serviceId = await _servicesService.CreateAsync(serviceRequest);

        var services = await _servicesService.GetAllAsync();
        var createdService = GetServiceById(services, serviceId);
        createdService?.Id.Should().Be(serviceId);
        createdService?.Name.Should().Be(serviceRequest.Name);
        createdService?.Name.Should().Be(serviceRequest.Description);
    }

    [Test]
    public async Task Given_CreatePossibleValue_Then_NewServiceIsAvailableOnServicesList()
    {
        var categoryRequest = ServicesFaker.CreateCategory();
        var categoryId = await _categoriesService.CreateAsync(categoryRequest);
        var serviceRequest = ServicesFaker.CreateService(categoryId);
        var serviceId = await _servicesService.CreateAsync(serviceRequest);
        var services = await _servicesService.GetAllAsync();
        var createdService = services.FirstOrDefault(serviceDto => serviceDto.Id == serviceId);
        await _servicesService.AddAttributeAsync(new CreateAttributeRequest
        {
            Name = serviceRequest.Name,
            ServiceId = serviceId,
        });

        createdService?.Id.Should().Be(serviceId);
        createdService?.Name.Should().Be(serviceRequest.Name);
        createdService?.Name.Should().Be(serviceRequest.Description);
    }
}
