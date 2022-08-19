namespace Divstack.Company.Estimation.Tool.Services.Core.Services;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IServicesRepository
{
    Task AddAsync(Service service, CancellationToken cancellationToken = default);
    Task DeleteAsync(Service service, CancellationToken cancellationToken = default);
    Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<Service>> GetBatchAsync(IReadOnlyCollection<Guid> serviceIds,
        int limitItems = 25,
        CancellationToken cancellationToken = default);
    Task<Service> GetAsync(Guid publicId, CancellationToken cancellationToken = default);
}
