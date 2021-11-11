using System.Data;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Data;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}
