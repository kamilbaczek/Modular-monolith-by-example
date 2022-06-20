namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Reminder;

using Events;
using NServiceBus;

internal sealed class ValuationsDeadlineCloseReminder : IValuationsDeadlineCloseReminder
{
    private readonly IMessageSession _messageSession;
    public ValuationsDeadlineCloseReminder(IMessageSession messageSession)
    {
        _messageSession = messageSession;
    }

    public async Task RemindAsync(Guid valuationId, int daysBeforeDeadline,
        CancellationToken cancellationToken = default)
    {
        var @event = new PriorityCloseToDeadlineRemind(valuationId, daysBeforeDeadline);
        await _messageSession.Publish(@event);
    }
}
