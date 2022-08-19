namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services.Extensions;

using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

internal static class ServicesExtensions
{
    internal static ServiceDto GetService(this IEnumerable<ServiceDto> services, Guid serviceId) =>
        services.FirstOrDefault(serviceDto => serviceDto.Id == serviceId);
}
