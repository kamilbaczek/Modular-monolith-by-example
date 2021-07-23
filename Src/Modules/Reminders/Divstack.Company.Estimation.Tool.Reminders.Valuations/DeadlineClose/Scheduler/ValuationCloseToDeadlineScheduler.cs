using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Scheduler
{
    internal sealed class ValuationCloseToDeadlineScheduler : INotificationHandler<ValuationDeadlineFixedEvent>
    {
        private readonly IBackgroundJobScheduler _backgroundJobScheduler;
        private readonly IValuationsDeadlineCloseReminder _valuationsDeadlineCloseReminder;

        public ValuationCloseToDeadlineScheduler(IBackgroundJobScheduler backgroundJobScheduler, IValuationsDeadlineCloseReminder valuationsDeadlineCloseReminder)
        {
            _backgroundJobScheduler = backgroundJobScheduler;
            _valuationsDeadlineCloseReminder = valuationsDeadlineCloseReminder;
        }

        public Task Handle(ValuationDeadlineFixedEvent notification, CancellationToken cancellationToken)
        {
            _backgroundJobScheduler.Schedule(
                () => _valuationsDeadlineCloseReminder.RemindAsync(notification.Id, 1, cancellationToken),
                notification.Date);

            return Task.CompletedTask;
        }
    }
}
