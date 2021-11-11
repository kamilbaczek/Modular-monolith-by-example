using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

internal class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly UsersContext _usersContext;

    public RefreshTokenRepository(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    public async Task<RefreshToken> GetByUserPublicIdOrDefaultAsync(Guid userPublicId)
    {
        return await _usersContext.RefreshTokens.SingleOrDefaultAsync(t => t.UserPublicId == userPublicId);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _usersContext.RefreshTokens.AddAsync(refreshToken);
        await _usersContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task RemoveAsync(RefreshToken refreshToken)
    {
        _usersContext.RefreshTokens.Remove(refreshToken);
        await _usersContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task RemoveForUserAsync(Guid userPublicId)
    {
        var tokensToDelete =
            await _usersContext.RefreshTokens.Where(t => t.UserPublicId == userPublicId).ToListAsync();
        _usersContext.RefreshTokens.RemoveRange(tokensToDelete);
        await _usersContext.SaveChangesAsync(CancellationToken.None);
    }
}
