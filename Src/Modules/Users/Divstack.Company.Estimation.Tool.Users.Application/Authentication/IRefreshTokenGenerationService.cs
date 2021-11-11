using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

public interface IRefreshTokenGenerationService
{
    Task<string> GenerateRefreshTokenAsync(Guid userPublicId);
    Task<bool> HasValidRefreshTokenAsync(Guid userPublicId, string refreshToken);
}
