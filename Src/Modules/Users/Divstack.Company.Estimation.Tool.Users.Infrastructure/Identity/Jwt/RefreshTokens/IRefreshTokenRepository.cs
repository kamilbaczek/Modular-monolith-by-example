using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

internal interface IRefreshTokenRepository
{
    Task<RefreshToken> GetByUserPublicIdOrDefaultAsync(Guid userPublicId);
    Task AddAsync(RefreshToken refreshToken);
    Task RemoveAsync(RefreshToken refreshToken);
    Task RemoveForUserAsync(Guid userPublicId);
}
