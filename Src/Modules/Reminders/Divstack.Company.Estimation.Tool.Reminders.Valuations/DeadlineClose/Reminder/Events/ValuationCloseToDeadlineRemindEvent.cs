namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder.Events;

using System;
using Shared.DDD.BuildingBlocks;

public record ValuationCloseToDeadlineRemindEvent(Guid ValuationId, int DaysBeforeDeadline) : IntegrationEvent;
