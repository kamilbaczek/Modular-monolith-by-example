using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Contracts
{
    public interface ICartModule
    {
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}