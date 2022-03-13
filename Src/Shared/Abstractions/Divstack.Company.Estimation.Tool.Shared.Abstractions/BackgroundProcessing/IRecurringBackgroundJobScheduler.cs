namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;

using System;
using System.Linq.Expressions;

public interface IRecurringBackgroundJobScheduler
{
    void ScheduleHourly(string jobId, Expression<Action> methodCall);
}
