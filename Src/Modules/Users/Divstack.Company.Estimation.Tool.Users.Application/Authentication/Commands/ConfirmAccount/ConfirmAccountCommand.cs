using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ConfirmAccount;

public sealed class ConfirmAccountCommand : ICommand
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }

    internal class Handler : IRequestHandler<ConfirmAccountCommand>
    {
        private readonly IPasswordsManagementService _passwordsManagementService;

        public Handler(IPasswordsManagementService passwordsManagementService)
        {
            _passwordsManagementService = passwordsManagementService;
        }

        public async Task<Unit> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {
            await _passwordsManagementService.ConfirmUserEmailAndSetPasswordAsync(
                request.UserId,
                request.Token,
                request.Password);

            return Unit.Value;
        }
    }
}
