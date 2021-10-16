using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Exceptions;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Exceptions;
using Divstack.Company.Estimation.Tool.Services.Core.UserAccess;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Services
{
    internal sealed class ServicesService : IServicesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IServicesRepository _servicesRepository;

        public ServicesService(IServicesRepository servicesRepository,
            ICategoriesRepository categoriesRepository,
            ICurrentUserService currentUserService)
        {
            _servicesRepository = servicesRepository;
            _categoriesRepository = categoriesRepository;
            _currentUserService = currentUserService;
        }

        public async Task<List<ServiceDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var services = await _servicesRepository.GetAllAsync(cancellationToken);
            var servicesDtos = services.Select(ServiceDto.Map).ToList();

            return servicesDtos;
        }

        public async Task<List<ServiceDto>> GetBatchAsync(IReadOnlyCollection<Guid> serviceIds,
            int itemsLimit,
            CancellationToken cancellationToken = default)
        {
            var services = await _servicesRepository.GetBatchAsync(serviceIds, itemsLimit, cancellationToken);
            var servicesDtos = services.Select(ServiceDto.Map).ToList();

            return servicesDtos;
        }

        public async Task<Guid> CreateAsync(CreateServiceRequest createServiceRequest,
            CancellationToken cancellationToken = default)
        {
            var category = await _categoriesRepository.GetAsync(createServiceRequest.CategoryId, cancellationToken);
            ThrowIfCategoryNotFound(createServiceRequest.CategoryId, category);
            var service = Service.Create(
                createServiceRequest.Name,
                createServiceRequest.Description,
                category,
                _currentUserService);
            await _servicesRepository.AddAsync(service, cancellationToken);

            return service.Id;
        }

        public async Task Update(UpdateServiceRequest updateServiceRequest,
            CancellationToken cancellationToken = default)
        {
            var category = await _categoriesRepository.GetAsync(updateServiceRequest.CategoryId, cancellationToken);
            ThrowIfCategoryNotFound(updateServiceRequest.CategoryId, category);
            var service = await _servicesRepository.GetAsync(updateServiceRequest.ServiceId, cancellationToken);
            ThrowIfServiceNotFound(updateServiceRequest.ServiceId, service);
            service.Update(updateServiceRequest.Name, updateServiceRequest.Description, category);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var service = await _servicesRepository.GetAsync(id, cancellationToken);
            ThrowIfServiceNotFound(id, service);
            await _servicesRepository.DeleteAsync(service, cancellationToken);
        }

        public async Task AddAttributeAsync(CreateAttributeRequest createAttributeRequest,
            CancellationToken cancellationToken = default)
        {
            var service = await _servicesRepository.GetAsync(createAttributeRequest.ServiceId, cancellationToken);
            ThrowIfServiceNotFound(createAttributeRequest.ServiceId, service);
            service.AddAttribute(createAttributeRequest.Name);
            await _servicesRepository.CommitAsync(cancellationToken);
        }

        public async Task RemoveAttributeAsync(DeleteAttributeRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default)
        {
            var service = await _servicesRepository.GetAsync(deleteAttributeRequest.ServiceId, cancellationToken);
            ThrowIfServiceNotFound(deleteAttributeRequest.ServiceId, service);
            service.DeleteAttribute(deleteAttributeRequest.AttributeId);
            await _servicesRepository.CommitAsync(cancellationToken);
        }

        public async Task AddAttributePossibleValueAsync(CreatePossibleValueRequest createPossibleValueRequest,
            CancellationToken cancellationToken = default)
        {
            var service = await _servicesRepository.GetAsync(createPossibleValueRequest.ServiceId, cancellationToken);
            ThrowIfServiceNotFound(createPossibleValueRequest.ServiceId, service);
            service.AddAttributePotentialValue(createPossibleValueRequest.AttributeId,
                createPossibleValueRequest.Value);
            await _servicesRepository.CommitAsync(cancellationToken);
        }

        public async Task RemoveAttributePossibleValueAsync(DeletePossibleValueRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default)
        {
            var service = await _servicesRepository.GetAsync(deleteAttributeRequest.ServiceId, cancellationToken);
            ThrowIfServiceNotFound(deleteAttributeRequest.ServiceId, service);
            service.DeleteAttributePossibleValue(deleteAttributeRequest.AttributeId, deleteAttributeRequest.ServiceId);
            await _servicesRepository.CommitAsync(cancellationToken);
        }

        private static void ThrowIfCategoryNotFound(Guid id, Category category)
        {
            if (category is null)
                throw new CategoryNotFoundException(id);
        }

        private static void ThrowIfServiceNotFound(Guid id, Service service)
        {
            if (service is null)
                throw new ServiceNotFoundException(id);
        }
    }
}