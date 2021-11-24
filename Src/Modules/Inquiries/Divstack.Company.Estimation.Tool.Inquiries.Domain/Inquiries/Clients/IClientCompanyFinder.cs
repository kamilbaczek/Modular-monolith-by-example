namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;

using Shared.DDD.ValueObjects.Emails;

public interface IClientCompanyFinder
{
    Task<ClientCompany> FindCompany(Email email);
}
