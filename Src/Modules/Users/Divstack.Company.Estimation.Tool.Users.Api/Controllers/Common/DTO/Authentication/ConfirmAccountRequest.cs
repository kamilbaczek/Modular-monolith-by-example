using System;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

public class ConfirmAccountRequest
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}
