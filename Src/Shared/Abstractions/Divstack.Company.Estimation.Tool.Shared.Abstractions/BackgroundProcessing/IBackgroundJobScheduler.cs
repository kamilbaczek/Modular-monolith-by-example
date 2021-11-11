using System;
using System.Linq.Expressions;

namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;

public interface IBackgroundJobScheduler
{
    void Schedule(Expression<Action> methodCall, DateTime date);
    void UnSchedule(Expression<Action> methodCall);
}
