using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.DeleteUser
{
    internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserManagementService userManagementService;

        public DeleteUserCommandHandler(IUserManagementService userManagementService)
        {
            this.userManagementService = userManagementService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await userManagementService.DeleteAsync(request.PublicId, cancellationToken);

            return Unit.Value;
        }
    }
}