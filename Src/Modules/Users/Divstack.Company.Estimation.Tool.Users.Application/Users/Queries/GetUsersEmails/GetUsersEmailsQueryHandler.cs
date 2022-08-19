namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUsersEmails;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Authentication;
using GetUserEmail;
using MediatR;

internal sealed class GetUsersEmailsQueryHandler : IRequestHandler<GetUsersEmailsQuery, IReadOnlyList<string>>
{
    private readonly IUserManagementService _userManagementService;

    public GetUsersEmailsQueryHandler(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    public async Task<IReadOnlyList<string>> Handle(GetUsersEmailsQuery request,
        CancellationToken cancellationToken)
    {
        var allUsers = await _userManagementService.GetAllUsersAsync();
        var usersEmails = allUsers.Select(userDto => userDto.Email).ToList();

        return usersEmails;
    }

    public async Task<string> Handle(GetUserEmailQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(request.PublicId);

        return userDetails.Email;
    }
}
