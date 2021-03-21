using System;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Utils
{
    internal static class AsyncUtil
    {
        private static readonly TaskFactory TaskFactory = new
            TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        /// <summary>
        ///     Executes an async Task method which has a void return value synchronously
        ///     USAGE: AsyncUtil.RunSync(() => AsyncMethod());
        /// </summary>
        /// <param name="task">Task method to execute</param>
        internal static void RunSync(Func<Task> task)
            => TaskFactory
                .StartNew(task)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        ///     Executes an async Task
        ///     <T>
        ///         method which has a T return type synchronously
        ///         USAGE: T result = AsyncUtil.RunSync(() => AsyncMethod<T>());
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="task">Task<T> method to execute</param>
        /// <returns></returns>
        internal static TResult RunSync<TResult>(Func<Task<TResult>> task)
            => TaskFactory
                .StartNew(task)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}