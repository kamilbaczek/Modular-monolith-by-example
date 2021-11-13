namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

using System.Text.Json.Serialization;

public class SignInResponse
{
    [JsonPropertyName("token")] public string Token { get; set; }

    [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
}
