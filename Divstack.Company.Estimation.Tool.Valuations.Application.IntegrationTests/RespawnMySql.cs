using System.Threading.Tasks;
using MySqlConnector;
using Respawn;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests
{
    public class RespawnMySql : Checkpoint
    {
        public override async Task Reset(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await base.Reset(connection);
            }
        }
    }
}