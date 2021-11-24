namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;

using System;
using System.Threading;
using System.Threading.Tasks;

internal interface IValuationsDeadlineCloseReminder
{
    Task RemindAsync(Guid valuationId, int daysBeforeDeadline, CancellationToken cancellationToken = default);
}
