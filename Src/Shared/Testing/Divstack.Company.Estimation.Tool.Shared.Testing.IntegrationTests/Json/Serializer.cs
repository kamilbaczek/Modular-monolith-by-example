using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Json
{
    public static class Serializer
    {
        private static TObject DeserializeObject<TObject>(string value)
        {
            var settings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new PrivateResolver()
            };

            return JsonConvert.DeserializeObject<TObject>(value, settings);
        }

        public static async Task<T> GetResponseContent<T>(this HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            T result;
            try
            {
                result = DeserializeObject<T>(stringResponse);
            }
            catch (JsonReaderException ex)
            {
                var detailedExceptionMessage = $"Could not deserialize string: {stringResponse}, ex: {ex}";

                throw new JsonReaderException(detailedExceptionMessage);
            }

            return result;
        }

        public static StringContent GetRequestContent(object obj)
        {
            return new(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}