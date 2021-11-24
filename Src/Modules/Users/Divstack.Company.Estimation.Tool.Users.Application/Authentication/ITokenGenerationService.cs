namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System.Collections.Generic;
using DTOs;

public interface ITokenGenerationService
{
    string GenerateToken(UserDetailsDto userDetails, IEnumerable<string> roles);
}
