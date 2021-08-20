using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Configuration;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler
{
    internal sealed class ValuationCloseToDeadlineScheduler : INotificationHandler<ValuationDeadlineFixed>
    {
        private readonly IBackgroundJobScheduler _backgroundJobScheduler;
        private readonly IValuationsDeadlineCloseReminder _valuationsDeadlineCloseReminder;
        private readonly IDeadlinesCloseReminderConfiguration _deadlinesCloseReminderConfiguration;

        public ValuationCloseToDeadlineScheduler(IBackgroundJobScheduler backgroundJobScheduler,
            IValuationsDeadlineCloseReminder valuationsDeadlineCloseReminder,
            IDeadlinesCloseReminderConfiguration deadlinesCloseReminderConfiguration)
        {
            _backgroundJobScheduler = backgroundJobScheduler;
            _valuationsDeadlineCloseReminder = valuationsDeadlineCloseReminder;
            _deadlinesCloseReminderConfiguration = deadlinesCloseReminderConfiguration;
        }

        public Task Handle(ValuationDeadlineFixed valuationDeadlineFixed, CancellationToken cancellationToken)
        {
            var reminderDate =
                valuationDeadlineFixed.Deadline.AddDays(-_deadlinesCloseReminderConfiguration.DaysBeforeDeadline);
          _backgroundJobScheduler.Schedule(
                () => _valuationsDeadlineCloseReminder.RemindAsync(
                    valuationDeadlineFixed.ValuationId,
                    _deadlinesCloseReminderConfiguration.DaysBeforeDeadline,
                    cancellationToken),
                reminderDate);

            return Task.CompletedTask;
        }
    }
}
