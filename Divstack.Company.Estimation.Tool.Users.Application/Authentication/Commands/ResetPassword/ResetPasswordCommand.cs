using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ResetPassword
{
    public sealed class ResetPasswordCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }

        public class Handler : IRequestHandler<ResetPasswordCommand>
        {
            private readonly IPasswordsManagementService _passwordsManagementService;

            public Handler(IPasswordsManagementService passwordsManagementService)
            {
                _passwordsManagementService = passwordsManagementService;
            }

            public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                await _passwordsManagementService.ResetPasswordAsync(
                    request.UserId,
                    request.NewPassword,
                    request.Token,
                    cancellationToken);

                return Unit.Value;
            }
        }
    }
}