using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.Controllers;
using Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers
{
    internal class AuthenticationController : BaseController
    {
        private readonly IUserModule _userModule;

        public AuthenticationController(IUserModule userModule)
        {
            _userModule = userModule;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<SignInResponse>> SignIn([FromBody] SignInRequest request)
        {
            var signInCommandResponse = await _userModule.ExecuteCommandAsync(
                new SignInCommand(request.UserName, request.Password));

            var response = new SignInResponse
            {
                Token = signInCommandResponse.AccessToken,
                RefreshToken = signInCommandResponse.RefreshToken,
            };

            if (string.IsNullOrEmpty(signInCommandResponse.Error))
                return Ok(response);

            return UnauthorizedWithReason(signInCommandResponse.Error);
        }

        // [AllowAnonymous]
        // [HttpPost]
        // [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status500InternalServerError)]
        // public async Task<ActionResult<ConfirmAccountResponse>> ConfirmAccount([FromBody] ConfirmAccountRequest request)
        // {
        //     await _userModule.ExecuteCommandAsync(new ConfirmAccountCommand
        //     {
        //         UserId = request.UserId,
        //         Password = request.Password,
        //         Token = request.Token
        //     });
        //
        //     return Ok();
        // }
        //
        // [AllowAnonymous]
        // [HttpPost]
        // [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status500InternalServerError)]
        // public async Task<ActionResult<ResetPasswordResponse>> ResetPassword([FromBody] ResetPasswordRequest request)
        // {
        //     await _userModule.ExecuteCommandAsync(new ResetPasswordCommand
        //     {
        //         UserId = request.UserId,
        //         NewPassword = request.NewPassword,
        //         Token = request.Token
        //     });
        //
        //     return Ok();
        // }
        //
        // [AllowAnonymous]
        // [HttpPost]
        // public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword([FromBody] ForgotPasswordRequest request)
        // {
        //     await _userModule.ExecuteCommandAsync(new ForgotPasswordCommand
        //     {
        //         UserName = request.Email
        //     });
        //
        //     return Ok();
        // }
        //
        // [HttpPost]
        // [Authorize(Policy = PolicyNameKeys.TokenValid)]
        // public async Task<ActionResult<SignOutResponse>> SignOut([FromBody] SignOutRequest request)
        // {
        //     await _userModule.ExecuteCommandAsync(new SignOutCommand());
        //
        //     return Ok(new SignOutResponse());
        // }
        //
        // [AllowAnonymous]
        // public async Task<ActionResult<ExchangeRefreshTokenResponse>> ExchangeRefreshToken(
        //     [FromBody] ExchangeRefreshTokenCommand command)
        // {
        //     return await _userModule.ExecuteCommandAsync(command);
        // }
    }
}
