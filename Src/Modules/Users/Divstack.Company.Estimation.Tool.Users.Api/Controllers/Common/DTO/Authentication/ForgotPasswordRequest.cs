namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

using System.Text.Json.Serialization;

public class ForgotPasswordRequest
{
    [JsonPropertyName("email")] public string Email { get; set; }
}
