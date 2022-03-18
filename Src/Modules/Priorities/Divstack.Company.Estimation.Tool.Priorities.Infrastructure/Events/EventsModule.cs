﻿namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events;

using Common.Interfaces;
using Mapper;
using Microsoft.Extensions.DependencyInjection;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}