namespace Divstack.Company.Estimation.Tool.Sms.Core.Clients;

public interface ISmsClient
{
    Task SendAsync(string message, string to, string from = "", CancellationToken cancellationToken = default);
}
