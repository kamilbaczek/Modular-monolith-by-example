using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Swagger
{
    internal static class SwaggerAuthorizationExtensions
    {
        private const string Bearer = "Bearer";
        private const string Oauth2 = "oauth2";
        private const string Authorization = "Authorization";

        private static readonly string SecurityMessageDescription =
            $@"JWT Authorization header using the Bearer scheme.{Environment.NewLine}Enter 'Bearer' [space] and then your token in the text input below.{Environment.NewLine}Example: 'Bearer XXX'";


        internal static void AddJwtAuthorization(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(Bearer, new OpenApiSecurityScheme
            {
                Description = SecurityMessageDescription,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Name = Authorization,
                Scheme = Bearer
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = Bearer
                        },
                        Scheme = Oauth2,
                        Name = Bearer,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        }
    }
}