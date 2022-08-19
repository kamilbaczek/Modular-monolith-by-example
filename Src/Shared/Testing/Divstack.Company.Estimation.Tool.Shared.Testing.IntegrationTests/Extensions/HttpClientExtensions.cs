using System.Net.Http;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Json;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions
{
    public static class HttpClientExtentions
    {
        public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T command)
            where T : class
        {
            var commandAsString = Serializer.GetRequestContent(command);
            var response = await client.PostAsync(requestUri, commandAsString);

            return response;
        }
    }
}