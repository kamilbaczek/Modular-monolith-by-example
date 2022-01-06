namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt;

using System;
using System.Text;
using Application.Authentication;
using Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Policies;
using RefreshTokens;

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
                // options.Events = new JwtBearerEvents
                // {
                //     OnMessageReceived = context =>
                //     {
                //         var accessToken = context.Request.Query["access_token"];
                //
                //         var path = context.HttpContext.Request.Path;
                //         if (!string.IsNullOrEmpty(accessToken) &&
                //             path.StartsWithSegments("/hubs/approved"))
                //         {
                //             context.Token = accessToken;
                //         }
                //
                //         return Task.CompletedTask;
                //     }
                // };
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
