#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;

using Shared.DDD.ValueObjects.Emails;
using Shared.DDD.ValueObjects.PhoneNumbers;

public sealed class Client : ValueObject
{
    private Client()
    {
    }

    private Client(string firstName, string lastName, Email email, PhoneNumber phoneNumber, ClientCompany company)
    {
        Email = Guard.Against.Null(email, nameof(email));
        FirstName = Guard.Against.Null(firstName, nameof(firstName));
        LastName = Guard.Against.Null(lastName, nameof(lastName));
        Company = Guard.Against.Null(company, nameof(company));
        PhoneNumber = Guard.Against.Null(phoneNumber, nameof(phoneNumber));
    }

    private Email Email { get; }
    private PhoneNumber PhoneNumber { get; }
    internal string FullName => $"{FirstName} {LastName}";
    private string FirstName { get; }
    private string LastName { get; }
    private ClientCompany Company { get; }

    public static Client Of(string firstName, string lastName, Email email, PhoneNumber phoneNumber, ClientCompany company)
    {
        return new Client(firstName, lastName, email, phoneNumber, company);
    }
}
