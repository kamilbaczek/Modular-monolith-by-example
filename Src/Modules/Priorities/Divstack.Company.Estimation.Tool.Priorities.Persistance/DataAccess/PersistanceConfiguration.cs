namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.DataAccess;

using Domain.Priorities.Configurations;

internal static class PersistanceConfiguration
{
    internal static void Configure()
    {
        PrioritiesPersistanceConfiguration.Configure();
    }
}
