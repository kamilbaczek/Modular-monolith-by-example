using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Exceptions;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;

public sealed class Inquiry : Entity, IAggregateRoot
{
    private Inquiry()
    {
    }

    private Inquiry(
        IReadOnlyCollection<Service> services,
        Client client)
    {
        Guard.Against.NullOrEmpty(services, nameof(services));
        Client = Guard.Against.Null(client, nameof(client));

        Id = InquiryId.Create();
        InquiryItems = services
            .Select(service => InquiryItem.Create(service, this))
            .ToList()
            .AsReadOnly();

        AddDomainEvent(new InquiryMadeDomainEvent(Id));
    }

    public InquiryId Id { get; }
    private IReadOnlyList<InquiryItem> InquiryItems { get; }
    private Client Client { get; }

    internal static Inquiry Make(
        IReadOnlyList<Service> services,
        Client client)
    {
        return new Inquiry(services, client);
    }

    public static async Task<Inquiry> MakeAsync(
        IReadOnlyCollection<Service> services,
        Client client,
        IServiceExistingChecker serviceExistingChecker)
    {
        if (!services.Any())
        {
            throw new InquiryCannotBeEmptyException();
        }

        var servicesIds = services.Select(service => service.ServiceId.Value)
            .ToList()
            .AsReadOnly();
        var areServicesExists = await serviceExistingChecker.ExistAsync(servicesIds);
        if (areServicesExists is false)
        {
            throw new InvalidServicesException(servicesIds);
        }

        return new Inquiry(services, client);
    }
}
