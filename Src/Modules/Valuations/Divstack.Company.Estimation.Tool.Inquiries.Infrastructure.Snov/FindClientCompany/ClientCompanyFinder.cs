using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany
{
    internal sealed class ClientCompanyFinder : IClientCompanyFinder
    {
        private readonly ICompanyFinderHttpClient _companyFinderHttpClient;

        public ClientCompanyFinder(ICompanyFinderHttpClient companyFinderHttpClient)
        {
            _companyFinderHttpClient = companyFinderHttpClient;
        }

        public async Task<ClientCompany> FindCompany(Email email)
        {
            var clientProfile = await _companyFinderHttpClient.GetClientProfile(email.Value);
            var (companyName, size) = clientProfile.CurrentJobs.First();
            var clientCompany = ClientCompany.Of(size, companyName);

            return clientCompany;
        }
    }
}