namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt;

using System;
using System.Text;
using Application.Authentication;
using Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Policies;
using RefreshTokens;
using SignalR;

internal static class JwtTokenAuthorizationModule
{
    internal static void AddJwtTokenAuthorizationModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ITokenStoreManager, TokenStoreManager>();
        services.AddScoped<IAuthorizationHandler, TokenValidAuthorizationHandler>();
        services.AddSingleton<ITokenConfiguration, TokenConfiguration>();
        services.AddScoped<IJwtTokenManagementService, JwtTokenManagementService>();
        services.AddScoped<IRefreshTokenGenerationService, RefreshTokenGenerationService>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddSingleton<IUserIdProvider, UserPublicIdProvider>();

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
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = JwtSignalrAuthorization.ReadTokenFromQueryString
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
