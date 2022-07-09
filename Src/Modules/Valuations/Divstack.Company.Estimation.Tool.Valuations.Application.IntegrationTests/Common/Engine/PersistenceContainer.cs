namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Engine;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

internal static class PersistenceContainer
{
    private static readonly PostgreSqlTestcontainerConfiguration Database = new()
    {
        Database = "db",
        Username = "postgres",
        Password = "postgres",
        Port = 52574
    };

    private static readonly TestcontainerDatabase TestContainerDatabase =
        new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(Database)
            .WithWaitStrategy(Wait.ForUnixContainer())
            .Build();

    internal static Task StartAsync() => TestContainerDatabase.StartAsync();
    internal static void Stop() => TestContainerDatabase.DisposeAsync().AsTask();
}
