namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.BackgroundProcesses;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Abstractions.BackgroundProcessing;
using Tool.Priorities.Domain;

internal sealed class RedefinePrioritiesScheduler : IHostedService
{
    private const string RedefinePriorities = "redefine-priorities";
    private readonly IServiceScopeFactory _scopeFactory;

    public RedefinePrioritiesScheduler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var prioritiesRedefiner = scope.ServiceProvider.GetRequiredService<IPrioritiesRedefiner>();
        var backgroundJobScheduler = scope.ServiceProvider.GetRequiredService<IRecurringBackgroundJobScheduler>();

        backgroundJobScheduler.ScheduleHourly(RedefinePriorities, () => prioritiesRedefiner.RedefineAll());

        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
