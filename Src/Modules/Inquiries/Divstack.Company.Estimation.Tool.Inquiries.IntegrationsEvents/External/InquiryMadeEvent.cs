namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;

using NServiceBus;
using JsonSerializer = System.Text.Json.JsonSerializer;

public record InquiryMadeEvent(
    Guid InquiryId, int CompanySize) : IntegrationEvent, IMessage
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
