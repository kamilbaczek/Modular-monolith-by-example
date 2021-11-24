namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System;
using System.Collections.Generic;
using DTOs;

public interface IJwtTokenManagementService
{
    string GenerateJwtToken(UserDetailsDto userDetails, IList<string> roles);
    Guid GetUserPublicIdFromToken(string accessToken);
}
