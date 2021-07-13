using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Seeders
{
    internal sealed class ValuationRequestSeeder : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ValuationRequestSeeder(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();
                var valuations = await valuationsModule.ExecuteQueryAsync(new GetAllValuationsQuery());
                if (valuations.Valuations.Any())
                    return;

                var servicesService = scope.ServiceProvider.GetRequiredService<IServicesService>();
                var serviceId = await GetFirstServiceId(servicesService, cancellationToken);

                await RequestValuation(serviceId, valuationsModule);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static async Task RequestValuation(Guid serviceId, IValuationsModule valuationsModule)
        {
            var servicesIds = new List<Guid> {serviceId};
            var command = new RequestValuationCommand
            {
                Email = "kamilbaczek@mail.com",
                FirstName = "Kamil",
                LastName = "Baczek",
                ServicesIds = servicesIds,
            };

            await valuationsModule.ExecuteCommandAsync(command);
        }

        private static async Task<Guid> GetFirstServiceId(IServicesService servicesService,
            CancellationToken cancellationToken)
        {
            var serviceDtos = await servicesService.GetAllAsync(cancellationToken);
            var serviceId = serviceDtos.First().Id;
            return serviceId;
        }
    }
}
