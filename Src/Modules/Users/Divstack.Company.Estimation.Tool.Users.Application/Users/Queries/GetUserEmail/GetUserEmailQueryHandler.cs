namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;

using System.Threading;
using System.Threading.Tasks;
using Authentication;
using MediatR;

internal sealed class GetUserEmailQueryHandler : IRequestHandler<GetUserEmailQuery, string>
{
    private readonly IUserManagementService _userManagementService;

    public GetUserEmailQueryHandler(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    public async Task<string> Handle(GetUserEmailQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(request.PublicId);

        return userDetails.Email;
    }
}
