using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder.Events;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder
{
    internal sealed class ValuationsDeadlineCloseReminder : IValuationsDeadlineCloseReminder
    {
        private readonly IMediator _mediator;

        public ValuationsDeadlineCloseReminder(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RemindAsync(Guid valuationId, int daysBeforeDeadline, CancellationToken cancellationToken = default)
        {
            var @event = new ValuationCloseToDeadlineRemindEvent(valuationId, daysBeforeDeadline);
            await _mediator.Publish(@event, cancellationToken);
        }
    }
}
