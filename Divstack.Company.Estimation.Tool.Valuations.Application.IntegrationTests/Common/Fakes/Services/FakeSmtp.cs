using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using netDumbster.smtp;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes.Services
{
    internal static class FakeSmtp
    {
        private const string ServerAddressConfigurationName = "Mail:ServerAddress";
        private const string MailServerPortConfigurationName = "Mail:ServerPort";
        private const int DelayBeforeMailWillBeReceivedIn = 1000;

        internal static SimpleSmtpServer Create(IConfiguration configuration)
        {
            var serverAddress = configuration.GetValue<string>(ServerAddressConfigurationName);
            var port = configuration.GetValue<int>(MailServerPortConfigurationName);

            var ipAddress = IPAddress.Parse(serverAddress);
            var server = SimpleSmtpServer.Start(port);

            server.Configuration.WithAddress(ipAddress).WithPort(port);

            return server;
        }

        internal static void Destroy(this SimpleSmtpServer smtpServer)
        {
            smtpServer.Stop();
        }

        internal static async Task<SmtpMessage> GetRecentReceivedMessage(this SimpleSmtpServer smtpServer)
        {
            await Task.Delay(DelayBeforeMailWillBeReceivedIn);
            var email = smtpServer.ReceivedEmail.Last();

            return email;
        }
    }
}
