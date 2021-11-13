namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Authentication;
using Contracts;
using MediatR;
using Requests;

public class CreateUserCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public List<string> Roles { get; set; }

    internal sealed class Handler : IRequestHandler<CreateUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IPasswordsManagementService _passwordsManagementService;
        private readonly IUserManagementService _userManagementService;

        public Handler(IMediator mediator,
            IUserManagementService userManagementService,
            IPasswordsManagementService passwordsManagementService)
        {
            _mediator = mediator;
            _userManagementService = userManagementService;
            _passwordsManagementService = passwordsManagementService;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new CreateUserRequest(
                request.UserName,
                request.FirstName,
                request.LastName,
                request.Email,
                request.IsActive);

            var userPublicId = await _userManagementService.CreateUserAsync(user);
            await _userManagementService.AssignUserToRolesAsync(userPublicId, request.Roles);

            var token = await _passwordsManagementService.GenerateConfirmAccountTokenAsync(userPublicId);
            var @event = UserCreatedEvent.Create(userPublicId, request.Email, request.UserName, token);
            await _mediator.Publish(@event, cancellationToken);

            return Unit.Value;
        }
    }
}
