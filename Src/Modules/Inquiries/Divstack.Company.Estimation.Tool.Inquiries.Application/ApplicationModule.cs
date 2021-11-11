using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Mappers;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Application;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<IMapper<AskedServiceDto, Service>, ServiceDtoToServiceMapper>();

        return services;
    }
}
