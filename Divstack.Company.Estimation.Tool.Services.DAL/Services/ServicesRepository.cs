using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Services
{
    internal sealed class ServicesRepository : IServicesRepository
    {
        private readonly ServicesContext _servicesContext;

        public ServicesRepository(ServicesContext servicesContext)
        {
            _servicesContext = servicesContext;
        }

        public async Task AddAsync(Service service, CancellationToken cancellationToken = default)
        {
            await _servicesContext.AddAsync(service, cancellationToken);
            await _servicesContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Service service, CancellationToken cancellationToken = default)
        {
            _servicesContext.Services.Remove(service);
            await _servicesContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _servicesContext.Services
                .Include(service => service.Category)
                .OrderBy(service => service.Name)
                .ThenBy(service => service.Description)
                .ToListAsync(cancellationToken);
        }

        public async Task<Service> GetAsync(Guid publicId, CancellationToken cancellationToken = default)
        {
            return await _servicesContext.Services
                .Include(service => service.Category)
                .Include(service => service.Attributes)
                .ThenInclude(attribute =>  attribute.PossibleValues)
                .SingleOrDefaultAsync(service => service.Id == publicId, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _servicesContext.SaveChangesAsync(cancellationToken);
        }
    }
}
