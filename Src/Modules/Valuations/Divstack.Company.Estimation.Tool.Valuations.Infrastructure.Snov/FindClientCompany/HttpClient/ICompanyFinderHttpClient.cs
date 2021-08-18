using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient
{
    public interface ICompanyFinderHttpClient
    {
        Task<ClientProfileDto> GetClientProfile(string email);
    }
}


