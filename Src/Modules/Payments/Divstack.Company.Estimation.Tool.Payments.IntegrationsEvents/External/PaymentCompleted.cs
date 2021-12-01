namespace Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents.External;

public record PaymentCompleted(
    Guid PaymentId,
    Guid InquiryId) : IntegrationEvent;
