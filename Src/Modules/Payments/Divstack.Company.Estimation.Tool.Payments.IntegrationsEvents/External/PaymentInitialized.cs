namespace Divstack.Company.Estimation.Payments.IntegrationEvents.External;

public record PaymentInitialized(
    Guid PaymentId,
    Guid ValuationId,
    Guid InquiryId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
