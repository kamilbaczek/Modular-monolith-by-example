namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;

public record InquiryMadeEvent(
    Guid InquiryId, int CompanySize) : IntegrationEvent;
