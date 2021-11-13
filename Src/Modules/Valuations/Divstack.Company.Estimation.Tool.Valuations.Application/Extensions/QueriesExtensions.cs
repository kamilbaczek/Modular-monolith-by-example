namespace Divstack.Company.Estimation.Tool.Valuations.Application.Extensions;

using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

internal static class QueriesExtensions
{
    internal static async Task<IEnumerable<TDto>> ExecuteQueryAsync<TDto>(this IDbConnection connection,
        string query,
        dynamic dynamicParameters = null,
        CancellationToken cancellationToken = default,
        int? timeout = null)
    {
        var commandDefinition = new CommandDefinition(query,
            dynamicParameters,
            commandType: null,
            commandTimeout: timeout,
            cancellationToken: cancellationToken);
        return await connection.QueryAsync<TDto>(commandDefinition);
    }

    internal static async Task<TDto> ExecuteSingleQueryAsync<TDto>(this IDbConnection connection,
        string query,
        dynamic dynamicParameters = null,
        CancellationToken cancellationToken = default,
        int? timeout = null)
    {
        var commandDefinition = new CommandDefinition(query,
            dynamicParameters,
            commandType: null,
            commandTimeout: timeout,
            cancellationToken: cancellationToken);
        return await connection.QuerySingleAsync<TDto>(commandDefinition);
    }
}
