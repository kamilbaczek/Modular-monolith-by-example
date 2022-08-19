namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Reminder.Events;

using Shared.DDD.BuildingBlocks;

public record PriorityCloseToDeadlineRemind(Guid ValuationId, int DaysBeforeDeadline) : IIntegrationEvent;
