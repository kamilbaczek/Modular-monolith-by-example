using System.Text.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

public class ForgotPasswordRequest
{
    [JsonPropertyName("email")] public string Email { get; set; }
}
