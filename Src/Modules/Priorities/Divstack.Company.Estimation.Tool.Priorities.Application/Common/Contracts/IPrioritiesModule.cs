namespace Divstack.Company.Estimation.Tool.Priorities.Common.Contracts;

public interface IPrioritiesModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
