namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services.Attributes
{
    public sealed class Attribute
    {
        private Attribute()
        {
        }

        private Attribute(AttributeId attributeId,
            AttributeValueId valueId,
            Service service)
        {
            Service = service;
            Id = attributeId;
            ValueId = valueId;
        }

        private Service Service { get; }
        private AttributeId Id { get; }
        private AttributeValueId ValueId { get; }

        internal static Attribute Create(
            AttributeId attributeId,
            AttributeValueId attributeValueId,
            Service service)
        {
            return new Attribute(attributeId, attributeValueId, service);
        }
    }
}