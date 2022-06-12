namespace Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents.External;

using NServiceBus;

public record PaymentInitialized(
    Guid PaymentId,
    Guid ValuationId,
    Guid InquiryId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent, IMessage;
