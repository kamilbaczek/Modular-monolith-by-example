namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Repositories;

using Divstack.Company.Estimation.Tool.Services.Core.Services;
using MongoDB.Driver;

internal sealed class ServicesRepository : IServicesRepository
{
    private readonly IServicesContext _servicesContext;

    public ServicesRepository(IServicesContext servicesContext) => _servicesContext = servicesContext;

    public async Task AddAsync(Service service, CancellationToken cancellationToken = default)
    {
        var options = new InsertOneOptions();
        await _servicesContext.Services.InsertOneAsync(service, options, cancellationToken);
    }

    public async Task DeleteAsync(Service service, CancellationToken cancellationToken = default)
        => await _servicesContext.Services.DeleteOneAsync(serviceInStorage => serviceInStorage.Id == service.Id, cancellationToken);

    public async Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _servicesContext.Services.FindSync(FilterDefinition<Service>.Empty, null, cancellationToken)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Service>> GetBatchAsync(IReadOnlyCollection<Guid> serviceIds,
        int limitItems = 25,
        CancellationToken cancellationToken = default)
    {
        var sort = Builders<Service>.Sort
            .Ascending(service => service.Name)
            .Ascending(service => service.Description);
        var filter = Builders<Service>.Filter
            .In(service => service.Id, serviceIds);

        var options = new FindOptions<Service>
        {
            Limit = limitItems,
            Sort = sort
        };

        return await _servicesContext.Services
            .FindSync(filter, options)
            .ToListAsync(cancellationToken);
    }

    public async Task<Service> GetAsync(Guid publicId, CancellationToken cancellationToken = default)
    {
        var options = new FindOptions<Service>();
        return await _servicesContext.Services
            .FindSync(service => service.Id == publicId, options, cancellationToken)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
