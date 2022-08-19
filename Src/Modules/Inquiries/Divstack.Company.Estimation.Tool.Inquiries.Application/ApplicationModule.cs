[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Application;

using Domain.Inquiries.Items.Services;
using Inquiries.Commands.Make.Dtos;
using Inquiries.Commands.Make.Mappers;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<IMapper<AskedServiceDto, Service>, ServiceDtoToServiceMapper>();

        return services;
    }
}
