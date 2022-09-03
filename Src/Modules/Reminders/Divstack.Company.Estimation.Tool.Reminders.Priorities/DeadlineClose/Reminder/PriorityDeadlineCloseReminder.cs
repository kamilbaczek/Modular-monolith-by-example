namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Reminder;

using Events;
using NServiceBus;

internal sealed class PriorityDeadlineCloseReminder : IPriorityDeadlineCloseReminder
{
    private readonly IMessageSession _messageSession;
    public PriorityDeadlineCloseReminder(IMessageSession messageSession) => _messageSession = messageSession;

    public async Task RemindAsync(Guid valuationId, int daysBeforeDeadline,
        CancellationToken cancellationToken = default)
    {
        var @event = new PriorityCloseToDeadlineRemind(valuationId, daysBeforeDeadline);
        await _messageSession.Publish(@event);
    }
}
