namespace Divstack.Company.Estimation.Tool.Users.Application.Contracts;

using System.Threading.Tasks;

public interface IUserModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
