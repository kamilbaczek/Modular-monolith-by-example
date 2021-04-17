using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts
{
    internal sealed class ServiceExistingChecker : IServiceExistingChecker
    {
        private readonly IServicesRepository _servicesRepository;

        public ServiceExistingChecker(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task<bool> ExistAsync(Guid serviceId)
        {
            var service = await _servicesRepository.GetAsync(serviceId);

            return service is not null;
        }

        public async Task<bool> ExistAsync(List<Guid> serviceIds)
        {
            var services = await _servicesRepository.GetAllAsync();
            var servicesIdsFromDb = services.Select(service => service.Id).ToList();
            var allExists = serviceIds.All(id => servicesIdsFromDb.Contains(id));

            return allExists;
        }
    }
}
