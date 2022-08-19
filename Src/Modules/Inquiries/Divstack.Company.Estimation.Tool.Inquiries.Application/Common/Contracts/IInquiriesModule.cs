namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;

public interface IInquiriesModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
