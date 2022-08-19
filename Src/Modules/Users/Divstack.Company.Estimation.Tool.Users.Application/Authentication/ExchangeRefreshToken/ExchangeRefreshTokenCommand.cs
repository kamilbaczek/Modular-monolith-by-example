namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.ExchangeRefreshToken;

using Contracts;
using Microsoft.AspNetCore.Mvc;

public class ExchangeRefreshTokenCommand : ICommand<ActionResult<ExchangeRefreshTokenResponse>>
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
