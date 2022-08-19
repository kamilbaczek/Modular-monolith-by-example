﻿namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;

using System.Threading;
using System.Threading.Tasks;
using Authentication;
using MediatR;

internal sealed class
    GetUserDetailQueryByUsernameCommandHandler : IRequestHandler<GetUserDetailQueryByUsernameCommand,
        UserAccountDto>
{
    private readonly IUserManagementService _userManagementService;

    public GetUserDetailQueryByUsernameCommandHandler(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    public async Task<UserAccountDto> Handle(GetUserDetailQueryByUsernameCommand request,
        CancellationToken cancellationToken)
    {
        var userDetails = await _userManagementService.GetUserDetailsByUsernameAsync(request.Username);

        var accountDto = new UserAccountDto(
            userDetails.UserName,
            userDetails.Email,
            userDetails.PublicId,
            userDetails.Roles);

        return accountDto;
    }
}
