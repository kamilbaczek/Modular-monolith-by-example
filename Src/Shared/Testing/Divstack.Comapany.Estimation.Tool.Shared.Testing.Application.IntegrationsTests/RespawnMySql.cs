﻿using System.Threading.Tasks;
using MySqlConnector;
using Respawn;

namespace Divstack.Comapany.Estimation.Tool.Shared.Testing.Application.IntegrationsTests
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
