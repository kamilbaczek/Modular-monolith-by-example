using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services.Attributes;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Attribute = Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services.Attributes.Attribute;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services
{
    public sealed class Service : Entity
    {
        private Service()
        {
        }

        private Service(Guid serviceId)
        {
            ServiceId = new ServiceId(serviceId);
            Attributes = new List<Attribute>();
        }

        internal ServiceId ServiceId { get; }
        private IReadOnlyCollection<Attribute> Attributes { get; }

        public static Service Create(Guid serviceId)
        {
            return new Service(serviceId);
        }

        public void AddAttribute(AttributeId attributeId, AttributeValueId valueId)
        {
            Attribute.Create(attributeId, valueId, this);
        }
    }
}