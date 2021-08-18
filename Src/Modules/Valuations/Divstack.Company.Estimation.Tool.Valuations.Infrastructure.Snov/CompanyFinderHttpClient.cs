using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Requests;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient
{
    internal sealed class SnovHttpClient : ISnovHttpClient
    {
        private const string Snov = "snov";
        private readonly System.Net.Http.HttpClient _client;

        public SnovHttpClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(Snov);
        }

        public async Task<ClientProfileDto> GetClientProfile(string email)
        {
            var request = new FindProfileRequest("", email);
            var profileRequestAsJson = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _client.PostAsync("https://api.snov.io/v1/get-profile-by-email", profileRequestAsJson);

            httpResponse.EnsureSuccessStatusCode();
            return await httpResponse.Content.ReadFromJsonAsync<ClientProfileDto>();
        }
    }
}

