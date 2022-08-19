namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.ChangeUserPassword;

using System;
using System.Threading;
using System.Threading.Tasks;
using Authentication;
using Contracts;
using MediatR;

public sealed class ChangeUserPasswordCommand : ICommand
{
    public ChangeUserPasswordCommand(Guid publicId, string newPassword)
    {
        PublicId = publicId;
        NewPassword = newPassword;
    }

    public Guid PublicId { get; }
    public string NewPassword { get; }

    internal sealed class Handler : IRequestHandler<ChangeUserPasswordCommand>
    {
        private readonly IMediator _mediator;
        private readonly IPasswordsManagementService _passwordsManagementService;

        public Handler(IMediator mediator, IPasswordsManagementService passwordsManagementService)
        {
            _mediator = mediator;
            _passwordsManagementService = passwordsManagementService;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            await _passwordsManagementService.ChangeUserPasswordAsync(request.PublicId, request.NewPassword,
                cancellationToken);
            return Unit.Value;
        }
    }
}
