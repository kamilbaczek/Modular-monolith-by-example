namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Configurations;

using Categories;
using MongoDB.Bson.Serialization;

internal static class CategoryPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Category>(classMap =>
        {
            classMap.SetIgnoreExtraElements(true);
            classMap.MapIdProperty(category => category.Id).SetElementName("CategoryId");
            classMap.MapProperty(category => category.Description);
            classMap.MapProperty(category => category.Name);
        });
    }
}
