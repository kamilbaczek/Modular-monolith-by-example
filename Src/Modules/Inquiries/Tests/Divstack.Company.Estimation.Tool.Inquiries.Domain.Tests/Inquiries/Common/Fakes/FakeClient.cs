namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Tests.Inquiries.Common.Fakes;

using Domain.Inquiries.Clients;
using Shared.DDD.ValueObjects.Emails;
using Shared.DDD.ValueObjects.PhoneNumbers;

internal static class FakeClient
{
    internal static Client Create(
        string emailAsString = "test@mail.com",
        string phoneNumberAsString = "+48732121245",
        string companySize = "10-20",
        string companyName = "test company",
        string firstName = "test",
        string lastName = "test")
    {
        var email = Email.Of(emailAsString);
        var phoneNumber = PhoneNumber.Of(phoneNumberAsString);
        var clientCompany = ClientCompany.Of(companySize, companyName);
        var client = Client.Of(firstName, lastName, email, phoneNumber, clientCompany);

        return client;
    }
}
