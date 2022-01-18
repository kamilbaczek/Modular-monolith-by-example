namespace Divstack.Company.Estimation.Tool.Sms.Core.Clients;

public interface ISmsClient
{
    Task SendAsync(string message, string to, CancellationToken cancellationToken = default);
}
