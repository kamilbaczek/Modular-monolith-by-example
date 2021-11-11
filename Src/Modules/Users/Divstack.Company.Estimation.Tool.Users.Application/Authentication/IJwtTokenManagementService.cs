using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.DTOs;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

public interface IJwtTokenManagementService
{
    string GenerateJwtToken(UserDetailsDto userDetails, IList<string> roles);
    Guid GetUserPublicIdFromToken(string accessToken);
}
