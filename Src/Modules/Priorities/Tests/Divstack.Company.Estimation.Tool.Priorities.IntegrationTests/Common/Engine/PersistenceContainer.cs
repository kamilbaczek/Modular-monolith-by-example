namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common.Engine;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

internal static class PersistenceContainer
{
    private static readonly MongoDbTestcontainerConfiguration Database = new()
    {
        Database = "db",
        Username = "mongo",
        Password = "mongo",
        Port = 52575
    };

    private static readonly TestcontainerDatabase TestContainerDatabase =
        new TestcontainersBuilder<MongoDbTestcontainer>()
            .WithDatabase(Database)
            .WithWaitStrategy(Wait.ForUnixContainer())
            .Build();

    internal static Task StartAsync() => TestContainerDatabase.StartAsync();
    internal static void Stop() => TestContainerDatabase.DisposeAsync().AsTask();
}
