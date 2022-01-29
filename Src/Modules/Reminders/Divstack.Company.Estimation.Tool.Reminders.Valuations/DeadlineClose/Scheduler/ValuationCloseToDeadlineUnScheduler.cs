namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler;

using Configuration;
using MediatR;
using Reminder;
using Shared.Abstractions.BackgroundProcessing;
using Tool.Valuations.Domain.Valuations.Proposals.Events;

internal sealed class ValuationCloseToDeadlineUnScheduler :
    INotificationHandler<ProposalSuggestedDomainEvent>,
    INotificationHandler<ProposalCancelledDomainEvent>
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

    public Task Handle(ProposalCancelledDomainEvent proposalCancelledDomainEvent,
        CancellationToken cancellationToken)
    {
        UnSchedule(proposalCancelledDomainEvent.ValuationId.Value, cancellationToken);

        return Task.CompletedTask;
    }

    public Task Handle(ProposalSuggestedDomainEvent proposalSuggestedDomainEvent,
        CancellationToken cancellationToken)
    {
        UnSchedule(proposalSuggestedDomainEvent.ValuationId.Value, cancellationToken);

        return Task.CompletedTask;
    }

    private void UnSchedule(Guid valuationId, CancellationToken cancellationToken)
    {
        _backgroundJobScheduler.UnSchedule(
            () => _valuationsDeadlineCloseReminder.RemindAsync(
                valuationId,
                _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                cancellationToken));
    }
}
