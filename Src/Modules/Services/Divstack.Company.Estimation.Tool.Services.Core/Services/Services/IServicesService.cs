using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Services
{
    public interface IServicesService
    {
        Task<List<ServiceDto>> GetBatchAsync(IReadOnlyCollection<Guid> serviceIds,
            int itemsLimit,
            CancellationToken cancellationToken = default);

        Task<List<ServiceDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Guid> CreateAsync(CreateServiceRequest createServiceRequest, CancellationToken cancellationToken = default);
        Task Update(UpdateServiceRequest serviceToUpdate, CancellationToken cancellationToken = default);

        Task AddAttributeAsync(CreateAttributeRequest createAttributeRequest,
            CancellationToken cancellationToken = default);

        Task RemoveAttributeAsync(DeleteAttributeRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default);

        Task AddAttributePossibleValueAsync(CreatePossibleValueRequest createPossibleValueRequest,
            CancellationToken cancellationToken = default);

        Task RemoveAttributePossibleValueAsync(DeletePossibleValueRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}