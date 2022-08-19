namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.Core.Services;
using MongoDB.Driver;

internal interface IServicesContext
{
    public IMongoCollection<Service> Services { get; }
    public IMongoCollection<Category> Categories { get; }
}
