namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Authentication;
using Application.Authentication.DTOs;
using Claims;
using Configuration;
using Domain;
using Microsoft.IdentityModel.Tokens;

internal sealed class JwtTokenManagementService : IJwtTokenManagementService
{
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
    private readonly ITokenConfiguration tokenConfiguration;

    public JwtTokenManagementService(ITokenConfiguration tokenConfiguration, IDateTimeProvider dateTimeProvider)
    {
        this.tokenConfiguration = tokenConfiguration;
        this.dateTimeProvider = dateTimeProvider;
        if (jwtSecurityTokenHandler == null)
        {
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
    }

    public Guid GetUserPublicIdFromToken(string accessToken)
    {
        var principal = jwtSecurityTokenHandler.ValidateToken(accessToken, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret)),
            ValidIssuer = tokenConfiguration.Issuer,
            ValidAudience = tokenConfiguration.Audience,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime =
                false // we do not validate lifetime - token can be expired and we will generate new one based on refresh token
        }, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        var publicUserId = principal.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

        return Guid.Parse(publicUserId);
    }

    public string GenerateJwtToken(UserDetailsDto userDetails, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userDetails.PublicId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Email, userDetails.Email),
            new(CustomClaimTypes.FirstName,
                !string.IsNullOrEmpty(userDetails.FirstName) ? userDetails.FirstName : ""),
            new(CustomClaimTypes.LastName,
                !string.IsNullOrEmpty(userDetails.LastName) ? userDetails.LastName : "")
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(tokenConfiguration.Issuer,
            tokenConfiguration.Audience,
            claims,
            expires: dateTimeProvider.Now.AddMinutes(tokenConfiguration.AccessExpirationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityTokenHandler.WriteToken(token);
    }
}
