using System.Reflection;
using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Core;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello
{
    internal static class TrelloModule
    {
        private const string Configuration = "Configuration";
        private const string EventHandler = "EventHandler";

        internal static IServiceCollection AddTrello(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.Scan(scan => scan.FromAssemblyOf<RequestCreatedTrelloEventHandler>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            services.Scan(scan => scan.FromAssemblyOf<RequestCreatedTrelloEventHandler>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith(EventHandler)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.AddScoped<ITrelloTaskCreator, TrelloTaskCreator>();

            return services;
        }

        internal static void UseTrello(this IApplicationBuilder app)
        {
            app.UseTrelloAuthentication();
        }
    }
}

