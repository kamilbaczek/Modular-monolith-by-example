using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.ClientProfile;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer;

internal sealed class CompanyFinderHttpClient : ICompanyFinderHttpClient
{
    private const string Snov = "snov";
    // private const string JsonType = "application/json";
    // private readonly HttpClient _client;
    // private string _httpsApiSnovIoV1GetProfileByEmail = "https://api.snov.io/v1/get-profile-by-email";

    public CompanyFinderHttpClient(IHttpClientFactory httpClientFactory)
    {
        // _client = httpClientFactory.CreateClient(Snov);
    }

    public async Task<ClientProfileDto> GetClientProfile(string email)
    {
        //TODO implement real snov.io integration and remove mock
        //var request = new FindProfileRequest("", email);
        // var profileRequestAsJson = new StringContent(
        //     JsonSerializer.Serialize(request),
        //     Encoding.UTF8,
        //     JsonType);
        // var clientProfile = await GetClientProfile(profileRequestAsJson);

        var mockedClientJob = new CurrentJobDto("Test Company inc", "150-10");
        var mockedClientProfile = new ClientProfileDto(new List<CurrentJobDto> {mockedClientJob});

        return await Task.FromResult(mockedClientProfile);
    }

    //TODO implement real snov.io integration and remove mock
    // private async Task<ClientProfileDto> GetClientProfile(StringContent profileRequestAsJson)
    // {
    //     using var httpResponse =
    //         await _client.PostAsync(_httpsApiSnovIoV1GetProfileByEmail, profileRequestAsJson);
    //     httpResponse.EnsureSuccessStatusCode();
    //     var clientProfile = await httpResponse.Content.ReadFromJsonAsync<ClientProfileDto>();
    //     return clientProfile;
    // }
}
