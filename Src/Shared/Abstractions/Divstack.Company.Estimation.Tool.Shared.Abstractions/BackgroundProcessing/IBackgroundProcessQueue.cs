using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing
{
    public interface IBackgroundProcessQueue
    {
        void Enqueue(Expression<Func<Task>> methodCall);
    }
}