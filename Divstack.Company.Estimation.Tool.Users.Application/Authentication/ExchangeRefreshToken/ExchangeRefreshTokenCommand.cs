using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.ExchangeRefreshToken
{
    public class ExchangeRefreshTokenCommand : ICommand<ActionResult<ExchangeRefreshTokenResponse>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}