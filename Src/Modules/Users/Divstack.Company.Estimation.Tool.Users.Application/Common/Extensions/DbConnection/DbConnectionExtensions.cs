namespace Divstack.Company.Estimation.Tool.Users.Application.Common.Extensions.DbConnection;

using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

internal static class DbConnectionExtensions
{
    internal static async Task ExecuteStoredProcedureAsync(this IDbConnection connection,
        string procedureName,
        DynamicParameters dynamicParameters = null,
        CancellationToken cancellationToken = default,
        int? timeout = null)
    {
        var commandDefinition = new CommandDefinition(procedureName,
            dynamicParameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: timeout,
            cancellationToken: cancellationToken);
        await connection.ExecuteAsync(commandDefinition);
    }

    internal static async Task<TDto> ExecuteStoredProcedureAsync<TDto>(this IDbConnection connection,
        string procedureName,
        DynamicParameters dynamicParameters = null,
        CancellationToken cancellationToken = default,
        int? timeout = null) where TDto : class
    {
        var commandDefinition = new CommandDefinition(procedureName,
            dynamicParameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: timeout,
            cancellationToken: cancellationToken);

        return await connection.QueryFirstOrDefaultAsync<TDto>(commandDefinition);
    }

    internal static async Task ExecuteStoredProcedureAsync(this IDbConnection connection,
        string procedureName,
        object dynamicParameters = null,
        CancellationToken cancellationToken = default,
        int? timeout = null)
    {
        var commandDefinition = new CommandDefinition(procedureName,
            dynamicParameters,
            commandType: CommandType.StoredProcedure,
            commandTimeout: timeout,
            cancellationToken: cancellationToken);
        await connection.ExecuteAsync(commandDefinition);
    }
}
