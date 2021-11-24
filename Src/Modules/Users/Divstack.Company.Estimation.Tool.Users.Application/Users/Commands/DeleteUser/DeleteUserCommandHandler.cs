namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.DeleteUser;

using System.Threading;
using System.Threading.Tasks;
using Authentication;
using MediatR;

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
