namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Engine;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

internal static class PersistenceContainer
{
    private static readonly TestcontainerDatabase TestContainerDatabase = new ContainerBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration
        {
            Database = "db",
            Username = "postgres",
            Password = "postgres",
            Port = 52574
        })
        .Build();

    internal static async Task StartAsync() => await TestContainerDatabase.StartAsync();
    internal static async Task StopAsync() => await TestContainerDatabase.DisposeAsync();
}
