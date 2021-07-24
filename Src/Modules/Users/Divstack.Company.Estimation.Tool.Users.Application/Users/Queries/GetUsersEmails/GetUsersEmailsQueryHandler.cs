using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUsersEmails
{
    internal sealed class GetUsersEmailsQueryHandler : IRequestHandler<GetUsersEmailsQuery, IReadOnlyList<string>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetUsersEmailsQueryHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<string> Handle(GetUserEmailQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(request.PublicId);

            return userDetails.Email;
        }

        public async Task<IReadOnlyList<string>> Handle(GetUsersEmailsQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userManagementService.GetAllUsersAsync();
            var usersEmails = allUsers.Select(userDto => userDto.Email).ToList();

            return usersEmails;
        }
    }
}
