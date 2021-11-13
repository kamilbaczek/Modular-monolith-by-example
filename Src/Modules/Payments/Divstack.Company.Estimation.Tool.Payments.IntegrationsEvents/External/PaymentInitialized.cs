namespace Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents.External;

public record PaymentInitialized(
    Guid PaymentId,
    Guid ValuationId,
    Guid InquiryId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
