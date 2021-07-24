using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder.Events
{
    public record ValuationCloseToDeadlineRemindEvent(Guid ValuationId, int DaysBeforeDeadline): IntegrationEvent;
}
