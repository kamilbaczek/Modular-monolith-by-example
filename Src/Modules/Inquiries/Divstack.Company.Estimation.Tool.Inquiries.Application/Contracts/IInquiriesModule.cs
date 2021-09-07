using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts
{
    public interface IInquiriesModule
    {
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
