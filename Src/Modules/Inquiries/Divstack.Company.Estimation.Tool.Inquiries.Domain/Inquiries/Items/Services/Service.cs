namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;

using Attributes;

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
