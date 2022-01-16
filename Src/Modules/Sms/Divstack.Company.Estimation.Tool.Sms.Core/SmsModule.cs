using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]

namespace Divstack.Company.Estimation.Tool.Sms.Core;

using Clients;
using Configurations;
using Configurations.PhoneNumbers;
using Configurations.Sms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twilio;

internal static class SmsModule
{
    internal static IServiceCollection AddSmsCoreModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISmsClient, SmsClient>();
        var smsConfiguration = new SmsConfiguration(configuration);
        TwilioClient.Init(smsConfiguration.AccountSid, smsConfiguration.AuthToken);
        services.AddScoped<IPhoneNumbersConfiguration, PhoneNumbersConfiguration>();

        return services;
    }
}
