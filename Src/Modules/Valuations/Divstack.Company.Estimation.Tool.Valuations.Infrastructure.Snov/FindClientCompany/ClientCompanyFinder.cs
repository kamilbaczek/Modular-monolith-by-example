using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.ApiConsumer;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany
{
    internal  sealed class ClientCompanyFinder : IClientCompanyFinder
    {
        private readonly ICompanyFinderHttpClient _companyFinderHttpClient;

        public ClientCompanyFinder(ICompanyFinderHttpClient companyFinderHttpClient)
        {
            _companyFinderHttpClient = companyFinderHttpClient;
        }

        public async Task<ClientCompany> FindCompany(Email email)
        {
            var clientProfile = await _companyFinderHttpClient.GetClientProfile(email.Value);
            var currentCompany = clientProfile.CurrentJobs.First();
            var clientCompany = ClientCompany.Of(currentCompany.Size, currentCompany.CompanyName);

            return clientCompany;
        }
    }
}
