namespace Divstack.Company.Estimation.Tool.Sms.Core.Clients.Exceptions;

public sealed class SendSmsFailedException : InvalidOperationException
{
    public SendSmsFailedException(Exception smsClientException) : base(GetMessage(smsClientException))
    {
    }
    private static string GetMessage(Exception smsClientException)
    {
        return $"Send sms failed - {typeof(Exception)}:'{smsClientException.Message}'";
    }
}
