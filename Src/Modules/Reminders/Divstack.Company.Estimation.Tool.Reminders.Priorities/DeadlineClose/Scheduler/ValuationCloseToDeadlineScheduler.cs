namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Scheduler;

using Configuration;
using NServiceBus;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Tool.Priorities.IntegrationsEvents.ExternalEvents;

internal sealed class ValuationCloseToDeadlineScheduler : IHandleMessages<PriorityDefined>
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

    public Task Handle(PriorityDefined priorityDefined, IMessageHandlerContext context)
    {
        var reminderDate =
            priorityDefined.DeadlineDate.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
        _backgroundJobScheduler.Schedule(
            () => _valuationsDeadlineCloseReminder.RemindAsync(
                priorityDefined.ValuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                default),
            reminderDate);

        return Task.CompletedTask;
    }
}
