namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Utils;

internal static class AsyncUtil
{
    private static readonly TaskFactory TaskFactory = new(CancellationToken.None,
        TaskCreationOptions.None,
        TaskContinuationOptions.None,
        TaskScheduler.Default);
    
    internal static void RunSync(Func<Task> task)
    {
        TaskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }
    
    internal static TResult RunSync<TResult>(Func<Task<TResult>> task)
    {
        return TaskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }
}
