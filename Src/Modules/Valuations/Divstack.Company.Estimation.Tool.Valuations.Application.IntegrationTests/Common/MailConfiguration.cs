using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common
{
    internal static class MailConfiguration
    {
        internal static string MailFrom(IConfiguration configuration)
        {
            return configuration.GetValue<string>("Mail:MailFrom");
        }
    }
}