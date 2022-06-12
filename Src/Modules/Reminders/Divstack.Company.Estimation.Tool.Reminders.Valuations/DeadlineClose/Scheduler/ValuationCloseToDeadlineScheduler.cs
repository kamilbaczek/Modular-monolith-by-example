namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler;

using Configuration;
using NServiceBus;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;

internal sealed class ValuationCloseToDeadlineScheduler : IHandleMessages<ValuationRequested>
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

    // public ValueTask Handle(ValuationRequested proposalApprovedEvent, CancellationToken cancellationToken)
    // {
    // var reminderDate =
    //     proposalApprovedEvent.Deadline.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
    // _backgroundJobScheduler.Schedule(
    //     () => _valuationsDeadlineCloseReminder.RemindAsync(
    //         proposalApprovedEvent.ValuationId,
    //         _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
    //         cancellationToken),
    //     reminderDate);

    // }

    public Task Handle(ValuationRequested message, IMessageHandlerContext context)
    {
        return Task.CompletedTask;
    }
}
