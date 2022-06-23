namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Services;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Attributes.Dtos;
using Attributes.PossibleValues.Dtos;
using Dtos;

public interface IServicesService
{
    Task<List<ServiceDto>> GetBatchAsync(IReadOnlyCollection<Guid> serviceIds,
        int itemsLimit,
        CancellationToken cancellationToken = default);

    Task<List<ServiceDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Guid> CreateAsync(CreateServiceRequest createServiceRequest,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(UpdateServiceRequest serviceToUpdate, CancellationToken cancellationToken = default);

    Task AddAttributeAsync(CreateAttributeRequest createAttributeRequest,
        CancellationToken cancellationToken = default);

    Task RemoveAttributeAsync(RemoveAttributeRequest removeAttributeRequest,
        CancellationToken cancellationToken = default);

    Task AddAttributePossibleValueAsync(CreatePossibleValueRequest createPossibleValueRequest,
        CancellationToken cancellationToken = default);

    Task RemoveAttributePossibleValueAsync(DeletePossibleValueRequest deleteAttributeRequest,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
