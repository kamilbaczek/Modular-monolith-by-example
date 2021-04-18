using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations
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
            Valuation = valuation ?? throw new ArgumentNullException(nameof(valuation));
            if (!serviceIds.Any())
                throw new InvalidOperationException("Cannot request valuation without products");
            InquiryServices = serviceIds.Select(serivceId => InquiryService.Create(serivceId, this)).ToList().AsReadOnly();
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        internal static Enquiry Create(
            Valuation valuation,
            IReadOnlyList<ServiceId> productsIds,
            Client client)
        {
            return new (valuation, productsIds, client);
        }

        internal Email ClientEmail => Client.Email;
        private Valuation Valuation  { get; }
        private IReadOnlyList<InquiryService> InquiryServices { get; }
        private Client Client { get; }
    }
}
