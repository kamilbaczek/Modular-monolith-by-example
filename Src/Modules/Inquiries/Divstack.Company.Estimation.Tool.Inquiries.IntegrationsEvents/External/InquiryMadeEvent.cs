namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;

using System.Text.Json;

public record InquiryMadeEvent(
    Guid InquiryId, int CompanySize) : IntegrationEvent
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
