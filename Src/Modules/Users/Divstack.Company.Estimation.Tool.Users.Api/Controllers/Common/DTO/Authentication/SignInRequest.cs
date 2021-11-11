using System.Text.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

public class SignInRequest
{
    public SignInRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public SignInRequest()
    {
    }

    [JsonPropertyName("email")] public string Email { get; set; }

    [JsonPropertyName("password")] public string Password { get; set; }
}
