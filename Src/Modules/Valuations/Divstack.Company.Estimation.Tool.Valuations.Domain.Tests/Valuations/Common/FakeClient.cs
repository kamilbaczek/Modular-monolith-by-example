using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common
{
    internal static class FakeClient
    {
        internal static Client CreateClientWithCompany(Email email)
        {
            var clientCompany = ClientCompany.Of("10-15", "Test Company");
            var client = Client.Of(email, "firstname", "lastname", clientCompany);

            return client;
        }
    }
}
