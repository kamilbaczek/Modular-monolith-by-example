namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Authentication;
using Application.Authentication.DTOs;
using Configuration;
using Microsoft.IdentityModel.Tokens;

public class TokenGenerationService : ITokenGenerationService
{
    private readonly ITokenConfiguration tokenConfiguration;

    public TokenGenerationService(ITokenConfiguration tokenConfiguration)
    {
        this.tokenConfiguration = tokenConfiguration;
    }

    public string GenerateToken(UserDetailsDto userDetails, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userDetails.PublicId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, userDetails.PublicId.ToString()),
            new(ClaimTypes.Email, userDetails.Email),
            new(ClaimTypes.GivenName, $"{userDetails.FirstName} {userDetails.LastName}")
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(tokenConfiguration.Issuer,
            tokenConfiguration.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(tokenConfiguration.AccessExpirationInMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
