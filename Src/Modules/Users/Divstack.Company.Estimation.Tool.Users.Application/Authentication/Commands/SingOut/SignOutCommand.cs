using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SingOut;

public class SignOutCommand : ICommand
{
    public class Handler : IRequestHandler<SignOutCommand>
    {
        private readonly ISignInManagementService signInManagementService;

        public Handler(ISignInManagementService signInManagementService)
        {
            this.signInManagementService = signInManagementService;
        }

        public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await signInManagementService.SignOutAsync();

            return Unit.Value;
        }
    }
}
