namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted.Sender;

internal record PaymentCompletedEmailRequest(
    string FirstName,
    string LastName,
    string ClientEmail,
    Guid PaymentId)
{
    internal string ClientFullName => $"{FirstName} {LastName}";
}
