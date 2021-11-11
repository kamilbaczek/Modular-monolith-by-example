using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

internal sealed class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
{
    private readonly IUserManagementService _userManagementService;

    public GetUserDetailQueryHandler(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(request.PublicId);

        var userDetailVm = new UserDetailVm
        {
            Email = userDetails.Email,
            PublicId = userDetails.PublicId,
            Roles = userDetails.Roles,
            FirstName = userDetails.FirstName,
            LastName = userDetails.LastName,
            IsActive = userDetails.IsActive,
            UserName = userDetails.UserName,
            PasswordExpirationDate = userDetails.PasswordExpirationDate
        };
        return userDetailVm;
    }
}
