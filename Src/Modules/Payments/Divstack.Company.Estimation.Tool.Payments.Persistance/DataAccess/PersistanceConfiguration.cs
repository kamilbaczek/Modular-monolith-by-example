namespace Divstack.Company.Estimation.Tool.Payments.Persistance.DataAccess;

using Domain.Payments.Configurations;

internal static class PersistanceConfiguration
{
    internal static void Configure() => PaymentPersistanceConfiguration.Configure();
}
