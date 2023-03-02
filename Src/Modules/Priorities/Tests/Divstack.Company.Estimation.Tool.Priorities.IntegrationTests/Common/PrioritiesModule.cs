namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common;

using Divstack.Company.Estimation.Tool.Priorities.Application.Common.Contracts;

internal static class PrioritiesModule
{
    internal static async Task<TResponse> ExecuteQueryAsync<TResponse>(Application.Common.Contracts.IQuery<TResponse> request)
    {
        using var scope = TestEngine.ServiceScopeFactory!.CreateScope();
        var valuationsModule = scope.ServiceProvider.GetRequiredService<IPrioritiesModule>();

        return await valuationsModule.ExecuteQueryAsync(request);
    }
}
