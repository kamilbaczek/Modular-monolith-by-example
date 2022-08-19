namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer;

using System.Threading.Tasks;
using Dtos.ClientProfile;

internal interface ICompanyFinderHttpClient
{
    Task<ClientProfileDto> GetClientProfile(string email);
}
