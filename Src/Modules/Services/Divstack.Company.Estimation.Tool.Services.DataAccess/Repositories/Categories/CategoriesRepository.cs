namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Repositories.Categories;

using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using MongoDB.Driver;

internal sealed class CategoriesRepository : ICategoriesRepository
{
    private readonly IServicesContext _servicesContext;

    public CategoriesRepository(IServicesContext servicesContext) => _servicesContext = servicesContext;

    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        var options = new InsertOneOptions();
        await _servicesContext.Categories.InsertOneAsync(category, options, cancellationToken);
    }

    public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        => await _servicesContext.Categories.DeleteOneAsync(categoryInStorage => categoryInStorage.Id == category.Id, cancellationToken);

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _servicesContext.Categories
            .FindSync(FilterDefinition<Category>.Empty, cancellationToken: cancellationToken)
            .ToListAsync(cancellationToken);

    public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _servicesContext.Categories.FindSync(category => category.Id == id, cancellationToken: cancellationToken)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
}
