  using System.Data;
  using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
  using Microsoft.Data.SqlClient;
  using Microsoft.Extensions.Configuration;

  namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess
  {
      internal sealed class DatabaseConnectionFactory : IDatabaseConnectionFactory
      {
          private readonly IConfiguration _configuration;
          private IDbConnection _connection;

          public DatabaseConnectionFactory(IConfiguration configuration)
          {
              _configuration = configuration;
          }

          public IDbConnection Create()
          {
              if (_connection is {State: ConnectionState.Open}) return _connection;
              _connection = new SqlConnection(_configuration.GetConnectionString(DataAccessConstants.ConnectionStringName));
              _connection.Open();

              return _connection;
          }

          public void Dispose()
          {
              if (_connection is {State: ConnectionState.Open}) _connection.Dispose();
          }
      }
  }
