using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;

public interface IPaymentsModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
