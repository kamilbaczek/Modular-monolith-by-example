namespace Divstack.Company.Estimation.Tool.Sms.Core.Clients.Exceptions;

public sealed class SendSmsFailedException : InvalidOperationException
{
    private static string GetMessage(Exception smsClientException) => $"Send sms failed - {typeof(Exception)}:'{smsClientException.Message}'";

    public SendSmsFailedException(Exception smsClientException) : base(GetMessage(smsClientException))
    {
    }
}
