using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.Application.IntegrationTests
{
    public sealed class RespawnMySql : Checkpoint
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
