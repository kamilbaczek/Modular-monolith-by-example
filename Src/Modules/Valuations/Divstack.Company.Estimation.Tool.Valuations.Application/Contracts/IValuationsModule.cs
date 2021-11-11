using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

public interface IValuationsModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
