namespace Divstack.Company.Estimation.Tool.Shared.Persistance.Mongo;

using Configuration;
using Microsoft.AspNetCore.Builder;

internal static class MongoExtensions
{
    internal static void UseMongo(this IApplicationBuilder app)
    {
        SharedValueObjectsPersistanceConfiguration.Configure();
    }
}
