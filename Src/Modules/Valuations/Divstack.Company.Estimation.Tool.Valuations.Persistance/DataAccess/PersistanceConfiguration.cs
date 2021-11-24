namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using Domain.Valuations.Configurations;

internal static class PersistanceConfiguration
{
    internal static void Configure()
    {
        ValuationPersistanceConfiguration.Configure();
    }
}
