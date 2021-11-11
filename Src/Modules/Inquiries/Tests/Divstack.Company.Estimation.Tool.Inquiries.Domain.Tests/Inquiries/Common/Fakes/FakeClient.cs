using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes;

internal static class FakeClient
{
    internal static Client Create(
        string emailAsString = "test@mail.com",
        string companySize = "10-20",
        string companyName = "test company",
        string firstName = "test",
        string lastName = "test")
    {
        var email = Email.Of(emailAsString);
        var clientCompany = ClientCompany.Of(companySize, companyName);
        var client = Client.Of(email, firstName, lastName, clientCompany);

        return client;
    }
}
