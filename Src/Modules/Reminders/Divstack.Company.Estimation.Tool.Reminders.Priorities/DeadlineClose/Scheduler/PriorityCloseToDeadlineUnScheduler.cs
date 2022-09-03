namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Scheduler;

using Configuration;
using NServiceBus;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class PriorityCloseToDeadlineUnScheduler :
    IHandleMessages<ProposalSuggested>,
    IHandleMessages<ProposalCancelled>
{
    private readonly IBackgroundJobScheduler _backgroundJobScheduler;
    private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;
    private readonly IPriorityDeadlineCloseReminder _priorityDeadlineCloseReminder;

    public PriorityCloseToDeadlineUnScheduler(IBackgroundJobScheduler backgroundJobScheduler,
        IPriorityDeadlineCloseReminder priorityDeadlineCloseReminder,
        IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
    {
        _backgroundJobScheduler = backgroundJobScheduler;
        _priorityDeadlineCloseReminder = priorityDeadlineCloseReminder;
        _deadlinesCloseReminderConfiguration = deadlinesCloseReminderConfiguration;
    }
    public Task Handle(ProposalCancelled proposalCancelled, IMessageHandlerContext context)
    {
        UnSchedule(proposalCancelled.ValuationId);

        return Task.CompletedTask;
    }

    public Task Handle(ProposalSuggested proposalSuggested, IMessageHandlerContext context)
    {
        UnSchedule(proposalSuggested.ValuationId);

        return Task.CompletedTask;
    }

    private void UnSchedule(Guid valuationId, CancellationToken cancellationToken = default)
    {
        _backgroundJobScheduler.UnSchedule(
            () => _priorityDeadlineCloseReminder.RemindAsync(
                valuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                cancellationToken));
    }
}
