namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System;
using System.Threading.Tasks;

public interface IRefreshTokenGenerationService
{
    Task<string> GenerateRefreshTokenAsync(Guid userPublicId);
    Task<bool> HasValidRefreshTokenAsync(Guid userPublicId, string refreshToken);
}
