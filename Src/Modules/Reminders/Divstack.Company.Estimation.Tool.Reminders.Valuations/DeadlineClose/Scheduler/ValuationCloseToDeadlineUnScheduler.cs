namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler;

using Configuration;
using NServiceBus;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ValuationCloseToDeadlineUnScheduler :
    IHandleMessages<ProposalSuggested>,
    IHandleMessages<ProposalCancelled>
{
    private readonly IBackgroundJobScheduler _backgroundJobScheduler;
    private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;
    private readonly IValuationsDeadlineCloseReminder _valuationsDeadlineCloseReminder;

    public ValuationCloseToDeadlineUnScheduler(IBackgroundJobScheduler backgroundJobScheduler,
        IValuationsDeadlineCloseReminder valuationsDeadlineCloseReminder,
        IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
    {
        _backgroundJobScheduler = backgroundJobScheduler;
        _valuationsDeadlineCloseReminder = valuationsDeadlineCloseReminder;
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
            () => _valuationsDeadlineCloseReminder.RemindAsync(
                valuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                cancellationToken));
    }
}
