namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Sender;

internal record PaymentInitializedEmailRequest(
    string FirstName,
    string LastName,
    string AmountToPayCurrency,
    decimal? AmountToPayValue,
    string ClientEmail,
    Guid PaymentId)
{
    internal string AmountToPay => $"{AmountToPayValue} {AmountToPayCurrency}";
    internal string ClientFullName => $"{FirstName} {LastName}";
}
