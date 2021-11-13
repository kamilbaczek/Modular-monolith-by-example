namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;

using System;

public class ResetPasswordRequest
{
    public Guid UserId { get; set; }
    public string NewPassword { get; set; }
    public string Token { get; set; }
}
