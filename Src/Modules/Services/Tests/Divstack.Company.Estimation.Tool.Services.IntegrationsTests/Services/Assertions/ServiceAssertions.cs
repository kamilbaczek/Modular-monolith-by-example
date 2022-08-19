namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services.Assertions;

using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using FluentAssertions;
using FluentAssertions.Primitives;


internal static class ServiceAssertionsExtensions
{
    public static ServiceAssertions Should(this ServiceDto instance) => new(instance);
}

internal sealed class ServiceAssertions :
    ReferenceTypeAssertions<ServiceDto, ServiceAssertions>
{
    public ServiceAssertions(ServiceDto instance)
        : base(instance)
    {
    }

    protected override string Identifier => nameof(ServiceDto);

    public void BeService(Guid serviceId, CreateServiceRequest request)
    {
        Subject.Id.Should().Be(serviceId);
        Subject.Name.Should().Be(request.Name);
        Subject.Description.Should().Be(request.Description);
        Subject.Category.Id.Should().Be(request.CategoryId);
        Subject.Category.Should().NotBeNull();
        Subject.Category.Id.Should().Be(request.CategoryId);
        Subject.Category.Name.Should().Be(request.Name);
    }
}
