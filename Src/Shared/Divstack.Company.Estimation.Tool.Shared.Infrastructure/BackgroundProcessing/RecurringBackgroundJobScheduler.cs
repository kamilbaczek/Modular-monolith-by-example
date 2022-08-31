namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using System.Linq.Expressions;
using Abstractions.BackgroundProcessing;
using Hangfire;
using Hangfire.Common;

internal sealed class RecurringBackgroundJobScheduler : IRecurringBackgroundJobScheduler
{
    public void ScheduleHourly(string jobId, Expression<Action> methodCall)
    {
        var manager = new RecurringJobManager();
        manager.AddOrUpdate(jobId, Job.FromExpression(methodCall), Cron.Hourly(1));
    }
}
