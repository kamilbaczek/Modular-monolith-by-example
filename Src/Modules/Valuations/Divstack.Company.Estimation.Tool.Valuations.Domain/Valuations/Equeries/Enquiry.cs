using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries
{
    public sealed class Enquiry : ValueObject
    {
        private Enquiry()
        {
        }

        private Enquiry(
            Valuation valuation,
            IReadOnlyList<ServiceId> serviceIds,
            Client client)
        {
            Valuation = Guard.Against.Null(valuation, nameof(valuation));
            if (!serviceIds.Any())
                throw new InvalidOperationException("Cannot request valuation without services");
            InquiryServices = serviceIds
                .Select(serviceId => InquiryService.Create(serviceId, this))
                .ToList()
                .AsReadOnly();
            Client = Guard.Against.Null(client, nameof(client));
        }

        internal Email ClientEmail => Client.Email;
        internal string ClientFullName => Client.FullName;
        private Valuation Valuation { get; }
        private IReadOnlyList<InquiryService> InquiryServices { get; }
        internal Client Client { get; }

        internal static Enquiry Create(
            Valuation valuation,
            IReadOnlyList<ServiceId> productsIds,
            Client client)
        {
            return new(valuation, productsIds, client);
        }
    }
}
