using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Mapper
{
    internal sealed class EventMapper : IEventMapper
    {
        public IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events)
        {
            return events.Select(Map).ToList();
        }

        private static IntegrationEvent Map(IDomainEvent @event)
        {
            return @event switch
            {
                InquiryMadeDomainEvent domainEvent =>
                    new InquiryMadeEvent(
                        domainEvent.InquiryId.Value),
                _ => null
            };
        }
    }
}