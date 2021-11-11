using System.Threading.Tasks;
using MySqlConnector;
using Respawn;

namespace Divstack.Company.Estimation.Tool.Shared.IntegrationTesting;

public sealed class RespawnMySql : Checkpoint
{
    public override async Task Reset(string connectionString)
    {
        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();
        await base.Reset(connection);
    }
}
