using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.ClientProfile;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.ApiConsumer
{
    internal interface ICompanyFinderHttpClient
    {
        Task<ClientProfileDto> GetClientProfile(string email);
    }
}


