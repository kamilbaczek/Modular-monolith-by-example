﻿namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common;

using Application.Common.Contracts;

internal static class ValuationModule
{
    internal static async Task ExecuteCommandAsync(ICommand request)
    {
        using var scope = TestEngine.ServiceScopeFactory!.CreateScope();
        var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

        await valuationsModule.ExecuteCommandAsync(request);
    }

    internal static async Task<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> request)
    {
        using var scope = TestEngine.ServiceScopeFactory!.CreateScope();
        var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

        return await valuationsModule.ExecuteQueryAsync(request);
    }
}
