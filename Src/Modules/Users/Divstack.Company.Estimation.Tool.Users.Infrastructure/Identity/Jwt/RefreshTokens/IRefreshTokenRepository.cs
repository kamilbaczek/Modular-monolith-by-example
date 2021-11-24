namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

using System;
using System.Threading.Tasks;
using Domain.Users;

internal interface IRefreshTokenRepository
{
    Task<RefreshToken> GetByUserPublicIdOrDefaultAsync(Guid userPublicId);
    Task AddAsync(RefreshToken refreshToken);
    Task RemoveAsync(RefreshToken refreshToken);
    Task RemoveForUserAsync(Guid userPublicId);
}
