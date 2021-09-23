using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Exceptions;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries
{
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
                throw new InvalidOperationException("Inquiry cannot be empty");
            var servicesIds = services.Select(service => service.ServiceId.Value)
                .ToList()
                .AsReadOnly();
            var areServicesExists = await serviceExistingChecker.ExistAsync(servicesIds);
            if (areServicesExists is false)
                throw new InvalidServicesException(servicesIds);

            return new Inquiry(services, client);
        }
    }
}