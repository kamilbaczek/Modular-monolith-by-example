namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common;

using Microsoft.Extensions.Configuration;

internal static class MailConfiguration
{
    internal static string MailFrom(IConfiguration configuration)
    {
        return configuration.GetValue<string>("Mail:MailFrom");
    }
}
