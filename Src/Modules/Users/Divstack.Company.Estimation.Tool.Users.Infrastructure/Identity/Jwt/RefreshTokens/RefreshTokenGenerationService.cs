namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Application.Authentication;
using Configuration;
using Domain;
using Domain.Users;

internal sealed class RefreshTokenGenerationService : IRefreshTokenGenerationService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenConfiguration _tokenConfiguration;

    public RefreshTokenGenerationService(IRefreshTokenRepository refreshTokenRepository,
        IDateTimeProvider dateTimeProvider, ITokenConfiguration tokenConfiguration)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _dateTimeProvider = dateTimeProvider;
        _tokenConfiguration = tokenConfiguration;
    }

    public async Task<string> GenerateRefreshTokenAsync(Guid userPublicId)
    {
        await RemoveTokenFromDbForUserIfExists(userPublicId);

        var refreshTokenString = GenerateRandomRefreshToken();
        await SaveTokenInDb(userPublicId, refreshTokenString);

        return refreshTokenString;
    }

    public async Task<bool> HasValidRefreshTokenAsync(Guid userPublicId, string refreshToken)
    {
        var userRefreshToken = await _refreshTokenRepository.GetByUserPublicIdOrDefaultAsync(userPublicId);
        if (userRefreshToken == null)
        {
            return false;
        }

        return userRefreshToken.Token == refreshToken && userRefreshToken.ExpiryDate > _dateTimeProvider.Now;
    }

    private static string GenerateRandomRefreshToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        var refreshTokenString = Convert.ToBase64String(bytes);

        return refreshTokenString;
    }

    private async Task SaveTokenInDb(Guid userPublicId, string refreshTokenString)
    {
        var refreshToken = new RefreshToken
        {
            Token = refreshTokenString,
            UserPublicId = userPublicId,
            ExpiryDate = _dateTimeProvider.Now.AddMinutes(_tokenConfiguration.RefreshExpirationInMinutes)
        };
        await _refreshTokenRepository.AddAsync(refreshToken);
    }

    private async Task RemoveTokenFromDbForUserIfExists(Guid userPublicId)
    {
        var existingRefreshToken = await _refreshTokenRepository.GetByUserPublicIdOrDefaultAsync(userPublicId);
        if (existingRefreshToken != null)
            await _refreshTokenRepository.RemoveAsync(existingRefreshToken);
    }
}
