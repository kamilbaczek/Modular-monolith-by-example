using System.Text.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication
{
    public class SignInResponse
    {
        [JsonPropertyName("token")] public string Token { get; set; }

        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
    }
}