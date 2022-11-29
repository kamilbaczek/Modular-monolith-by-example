namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes;

using Domain.Inquiries.Items.Services;

internal static class FakeService
{
    internal static List<Service> Create()
    {
        var service = Service.Create(new Guid());
        var services = new List<Service>
        {
            service
        };

        return services;
    }
}
