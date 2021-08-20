using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Configuration;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler
{
    internal sealed class ValuationCloseToDeadlineUnScheduler :
        INotificationHandler<ProposalSuggestedDomainEvent>,
        INotificationHandler<ProposalCancelledDomainEvent>
    {
        private readonly IBackgroundJobScheduler _backgroundJobScheduler;
        private readonly IValuationsDeadlineCloseReminder _valuationsDeadlineCloseReminder;
        private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;

        public ValuationCloseToDeadlineUnScheduler(IBackgroundJobScheduler backgroundJobScheduler,
            IValuationsDeadlineCloseReminder valuationsDeadlineCloseReminder,
            IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
        {
            _backgroundJobScheduler = backgroundJobScheduler;
            _valuationsDeadlineCloseReminder = valuationsDeadlineCloseReminder;
            _deadlinesCloseReminderConfiguration = deadlinesCloseReminderConfiguration;
        }

        public Task Handle(ProposalSuggestedDomainEvent proposalSuggestedDomainEvent, CancellationToken cancellationToken)
        {
            UnSchedule(proposalSuggestedDomainEvent.ValuationId.Value, cancellationToken);

            return Task.CompletedTask;
        }

        public Task Handle(ProposalCancelledDomainEvent proposalCancelledDomainEvent, CancellationToken cancellationToken)
        {
            UnSchedule(proposalCancelledDomainEvent.ValuationId.Value, cancellationToken);

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
}
