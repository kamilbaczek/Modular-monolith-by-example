namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Data;

using System.Data;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}
