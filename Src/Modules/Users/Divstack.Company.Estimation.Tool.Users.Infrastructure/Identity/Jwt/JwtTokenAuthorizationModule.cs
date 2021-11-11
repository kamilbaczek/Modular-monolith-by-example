using System;
using System.Text;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Configuration;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Policies;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt;

internal static class JwtTokenAuthorizationModule
{
    internal static void AddJwtTokenAuthorizationModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ITokenStoreManager, TokenStoreManager>();
        services.AddScoped<IAuthorizationHandler, TokenValidAuthorizationHandler>();
        services.AddSingleton<ITokenConfiguration, TokenConfiguration>();
        services.AddScoped<IJwtTokenManagementService, JwtTokenManagementService>();
        services.AddScoped<ITokenGenerationService, TokenGenerationService>();
        services.AddScoped<IRefreshTokenGenerationService, RefreshTokenGenerationService>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        var tokenConfiguration = new TokenConfiguration(configuration);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret)),
                    ValidIssuer = tokenConfiguration.Issuer,
                    ValidAudience = tokenConfiguration.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(PolicyNameKeys.TokenValid,
                policy => policy.Requirements.Add(new TokenValidRequirement()));
        });

        services.Configure<DataProtectionTokenProviderOptions>(o =>
            o.TokenLifespan = TimeSpan.FromMinutes(tokenConfiguration.LinksExpirationInMinutes));
        services.AddDistributedMemoryCache();
    }
}
