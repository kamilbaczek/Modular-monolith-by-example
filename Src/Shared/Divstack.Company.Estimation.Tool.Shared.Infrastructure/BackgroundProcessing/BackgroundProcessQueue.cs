using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Hangfire;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing
{
    internal sealed class BackgroundProcessQueue : IBackgroundProcessQueue
    {
        public void Enqueue(Expression<Func<Task>> methodCall)
        {
            BackgroundJob.Enqueue(methodCall);
        }
    }
}