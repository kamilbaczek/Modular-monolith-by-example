namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes;

using Domain.Inquiries.Clients;
using Shared.DDD.ValueObjects.Emails;

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
