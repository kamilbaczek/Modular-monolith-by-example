namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Scheduler;

using Configuration;
using NServiceBus;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Tool.Priorities.IntegrationsEvents.ExternalEvents;

internal sealed class PriorityCloseToDeadlineScheduler : IHandleMessages<PriorityDefined>
{
    private readonly IBackgroundJobScheduler _backgroundJobScheduler;
    private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;
    private readonly IPriorityDeadlineCloseReminder _priorityDeadlineCloseReminder;
    public PriorityCloseToDeadlineScheduler(IBackgroundJobScheduler backgroundJobScheduler,
        IPriorityDeadlineCloseReminder priorityDeadlineCloseReminder,
        IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
    {
        _backgroundJobScheduler = backgroundJobScheduler;
        _priorityDeadlineCloseReminder = priorityDeadlineCloseReminder;
        _deadlinesCloseReminderConfiguration = deadlinesCloseReminderConfiguration;
    }

    public Task Handle(PriorityDefined priorityDefined, IMessageHandlerContext context)
    {
        var reminderDate =
            priorityDefined.DeadlineDate.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
        _backgroundJobScheduler.Schedule(
            () => _priorityDeadlineCloseReminder.RemindAsync(
                priorityDefined.ValuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                default),
            reminderDate);

        return Task.CompletedTask;
    }
}
