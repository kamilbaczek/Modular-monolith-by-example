using System.Text.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication
{
    public class SignInRequest
    {
        [JsonPropertyName("email")] public string UserName { get; set; }

        [JsonPropertyName("password")] public string Password { get; set; }
    }
}
