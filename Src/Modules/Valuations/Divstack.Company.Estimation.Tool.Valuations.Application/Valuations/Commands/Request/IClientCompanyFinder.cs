using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients;
namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    public interface IClientCompanyFinder
    {
        Task<ClientCompany> FindCompany(Email email);
    }
}
