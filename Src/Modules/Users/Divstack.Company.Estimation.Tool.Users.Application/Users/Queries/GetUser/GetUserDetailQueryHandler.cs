namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

using System.Threading;
using System.Threading.Tasks;
using Authentication;
using MediatR;

internal sealed class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
{
    private readonly IUserManagementService _userManagementService;

    public GetUserDetailQueryHandler(IUserManagementService userManagementService) => 
        _userManagementService = userManagementService;

    public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(request.PublicId);

        var userDetailVm = new UserDetailVm(
            userDetails.FirstName,
            userDetails.LastName,
            userDetails.UserName,
            userDetails.Email,
            userDetails.PublicId,
            userDetails.Roles,
            userDetails.IsActive,
            userDetails.PasswordExpirationDate);
        
        return userDetailVm;
    }
}
