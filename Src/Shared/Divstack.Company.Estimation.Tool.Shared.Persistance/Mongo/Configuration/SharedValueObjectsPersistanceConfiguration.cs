namespace Divstack.Company.Estimation.Tool.Shared.Persistance.Mongo.Configuration;

using DDD.ValueObjects;
using MongoDB.Bson.Serialization;

internal static class SharedValueObjectsPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Money>(classMap =>
        {
            classMap.MapProperty(money => money.Value).SetIsRequired(true);
            classMap.MapProperty(money => money.Currency).SetIsRequired(true);
        });
    }
}
