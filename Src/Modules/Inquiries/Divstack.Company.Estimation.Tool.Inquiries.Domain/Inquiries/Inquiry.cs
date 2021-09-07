using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Exceptions;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries
{
    public sealed class Inquiry : Entity, IAggregateRoot
    {
        private Inquiry()
        {
        }

        private Inquiry(
            IReadOnlyList<ServiceId> serviceIds,
            Client client)
        {
            Guard.Against.NullOrEmpty(serviceIds, nameof(serviceIds));
            Client = Guard.Against.Null(client, nameof(client));
            Id = new InquiryId(Guid.NewGuid());
            InquiryServices = serviceIds
                .Select(serviceId => InquiryService.Create(serviceId, this))
                .ToList()
                .AsReadOnly();
            AddDomainEvent(new InquiryMadeDomainEvent(Id));
        }
        public InquiryId Id { get; }
        internal Email ClientEmail => Client.Email;
        internal string ClientFullName => Client.FullName;
        private IReadOnlyList<InquiryService> InquiryServices { get; }
        internal Client Client { get; }

        internal static Inquiry Make(
            IReadOnlyList<ServiceId> productsIds,
            Client client)
        {
            return new(productsIds, client);
        }

        public static async Task<Inquiry> MakeAsync(
            List<ServiceId> serviceIds,
            Client client,
            IServiceExistingChecker serviceExistingChecker)
        {
            var servicesIdsValues = serviceIds.Select(id => id.Value).ToList().AsReadOnly();
            var areServicesExists = await serviceExistingChecker.ExistAsync(servicesIdsValues);
            if (areServicesExists is false)
                throw new InvalidServicesException(serviceIds);

            return new Inquiry(serviceIds, client);
        }
    }
}
