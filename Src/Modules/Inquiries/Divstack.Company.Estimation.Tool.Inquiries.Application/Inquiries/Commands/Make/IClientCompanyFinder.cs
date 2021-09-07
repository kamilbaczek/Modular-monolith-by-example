using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make
{
    public interface IClientCompanyFinder
    {
        Task<ClientCompany> FindCompany(Email email);
    }
}
