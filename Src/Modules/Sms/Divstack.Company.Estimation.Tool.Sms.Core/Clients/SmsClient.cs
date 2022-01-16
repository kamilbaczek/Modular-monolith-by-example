namespace Divstack.Company.Estimation.Tool.Sms.Core.Clients;

using Configurations.PhoneNumbers;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

internal sealed class SmsClient : ISmsClient
{
    private readonly IPhoneNumbersConfiguration _phoneNumbersConfiguration;
    public SmsClient(IPhoneNumbersConfiguration  phoneNumbersConfiguration)
    {
        _phoneNumbersConfiguration = phoneNumbersConfiguration;
    }
    public async Task SendAsync(string message, string to, string from = "", CancellationToken cancellationToken = default)
    {
        from = string.IsNullOrEmpty(from) ? from : _phoneNumbersConfiguration.From;

        await MessageResource.CreateAsync(
            body: message,
            from: new PhoneNumber(from),
            to: new PhoneNumber(to)
        );

    }
}
