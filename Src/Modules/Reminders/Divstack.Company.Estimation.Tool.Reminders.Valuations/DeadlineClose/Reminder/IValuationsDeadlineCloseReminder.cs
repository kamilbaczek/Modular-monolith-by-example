using System;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder
{
    internal interface IValuationsDeadlineCloseReminder
    {
        Task RemindAsync(Guid valuationId, int daysBeforeDeadline, CancellationToken cancellationToken = default);
    }
}