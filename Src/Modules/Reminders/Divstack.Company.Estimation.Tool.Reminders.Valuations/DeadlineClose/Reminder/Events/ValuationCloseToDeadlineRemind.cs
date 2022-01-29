namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder.Events;

using Shared.DDD.BuildingBlocks;

public record ValuationCloseToDeadlineRemind(Guid ValuationId, int DaysBeforeDeadline) : IntegrationEvent;
