using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.DTOs;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication
{
    public interface ITokenGenerationService
    {
        string GenerateToken(UserDetailsDto userDetails, IEnumerable<string> roles);
    }
}