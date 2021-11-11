using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.ClientProfile;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer;

internal interface ICompanyFinderHttpClient
{
    Task<ClientProfileDto> GetClientProfile(string email);
}
