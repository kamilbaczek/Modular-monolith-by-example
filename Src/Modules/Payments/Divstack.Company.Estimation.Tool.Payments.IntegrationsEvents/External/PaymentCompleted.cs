namespace Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents.External;

using NServiceBus;

public record PaymentCompleted(
    Guid PaymentId,
    Guid InquiryId) : IntegrationEvent, IMessage;
