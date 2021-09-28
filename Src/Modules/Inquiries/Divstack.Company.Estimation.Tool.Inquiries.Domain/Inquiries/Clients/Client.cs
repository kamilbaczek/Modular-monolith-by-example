using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients
{
    public sealed class Client : ValueObject
    {
        private Client()
        {
        }

        private Client(Email email, string firstName, string lastName, ClientCompany company)
        {
            Email = Guard.Against.Null(email, nameof(email));
            FirstName = Guard.Against.Null(firstName, nameof(firstName));
            LastName = Guard.Against.Null(lastName, nameof(lastName));
            Company = Guard.Against.Null(company, nameof(company));
        }

        internal Email Email { get; }
        internal string FullName => $"{FirstName} {LastName}";
        private string FirstName { get; }
        private string LastName { get; }
        private ClientCompany Company { get; }

        public static Client Of(Email email, string firstName, string lastName, ClientCompany company)
        {
            return new Client(email, firstName, lastName, company);
        }
    }
}