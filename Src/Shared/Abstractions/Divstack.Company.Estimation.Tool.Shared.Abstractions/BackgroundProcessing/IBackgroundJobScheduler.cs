using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing
{
    public interface IBackgroundJobScheduler
    {
        void Schedule(Expression<Action> methodCall, DateTime date);
        void Run(Expression<Func<Task>> methodCall);
    }
}
