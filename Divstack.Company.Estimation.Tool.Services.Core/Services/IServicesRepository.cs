using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services
{
    public interface IServicesRepository
    {
        Task AddAsync(Service service, CancellationToken cancellationToken = default);
        Task DeleteAsync(Service service, CancellationToken cancellationToken = default);
        Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Service> GetAsync(Guid publicId, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}