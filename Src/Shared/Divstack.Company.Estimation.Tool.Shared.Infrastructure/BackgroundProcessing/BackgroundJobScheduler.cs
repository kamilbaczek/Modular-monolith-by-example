using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Hangfire;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing
{
    internal sealed class BackgroundJobScheduler : IBackgroundJobScheduler
    {
        public void Schedule(Expression<Action> methodCall, DateTime date)
        {
            var enqueueAt = new DateTimeOffset(date);
            BackgroundJob.Schedule(
                methodCall,
                enqueueAt);
        }

        public void Run(Expression<Func<Task>> methodCall)
        {
            BackgroundJob.Enqueue(methodCall);
        }
    }
}
