using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Configuration;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler;

internal sealed class ValuationCloseToDeadlineScheduler : INotificationHandler<ValuationRequested>
{
    private readonly IBackgroundJobScheduler _backgroundJobScheduler;
    private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;
    private readonly IValuationsDeadlineCloseReminder _valuationsDeadlineCloseReminder;

    public ValuationCloseToDeadlineScheduler(IBackgroundJobScheduler backgroundJobScheduler,
        IValuationsDeadlineCloseReminder valuationsDeadlineCloseReminder,
        IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
    {
        _backgroundJobScheduler = backgroundJobScheduler;
        _valuationsDeadlineCloseReminder = valuationsDeadlineCloseReminder;
        _deadlinesCloseReminderConfiguration = deadlinesCloseReminderConfiguration;
    }

    public Task Handle(ValuationRequested valuationRequested, CancellationToken cancellationToken)
    {
        var reminderDate =
            valuationRequested.Deadline.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
        _backgroundJobScheduler.Schedule(
            () => _valuationsDeadlineCloseReminder.RemindAsync(
                valuationRequested.ValuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                cancellationToken),
            reminderDate);

        return Task.CompletedTask;
    }
}
