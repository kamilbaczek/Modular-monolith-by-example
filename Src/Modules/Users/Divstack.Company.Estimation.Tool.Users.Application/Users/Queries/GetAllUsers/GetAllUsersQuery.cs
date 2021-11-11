using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IQuery<UserListVm>
{
    internal class Handler : IRequestHandler<GetAllUsersQuery, UserListVm>
    {
        private readonly IUserManagementService _userManagementService;

        public Handler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<UserListVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManagementService.GetAllUsersAsync();

            var usersOrdered = users
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();
            var result = new UserListVm(usersOrdered);

            return result;
        }
    }
}
