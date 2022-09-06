namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using System.Collections.Generic;

internal static class KeyVaultSecrets
{
    internal const string MongoDb = nameof(MongoDb);
    internal const string MySqlDb = nameof(MySqlDb);
    internal const string PostgresDb = nameof(PostgresDb);

    internal static readonly IList<string> Secrets = new List<string>
    {
        MongoDb,
        MySqlDb,
        PostgresDb
    };
}
