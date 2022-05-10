namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler;

using Configuration;
using MediatR;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ValuationCloseToDeadlineScheduler : IIntegrationEventHandler<ValuationRequested>
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

    public ValueTask Handle(ValuationRequested valuationRequested, CancellationToken cancellationToken)
    {
        // var reminderDate =
        //     valuationRequested.Deadline.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
        // _backgroundJobScheduler.Schedule(
        //     () => _valuationsDeadlineCloseReminder.RemindAsync(
        //         valuationRequested.ValuationId,
        //         _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
        //         cancellationToken),
        //     reminderDate);

        return new ValueTask();
    }
}
