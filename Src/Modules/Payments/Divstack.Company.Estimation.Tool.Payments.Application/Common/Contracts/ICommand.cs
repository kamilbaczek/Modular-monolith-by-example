namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;

public interface ICommand<TDto> : IQuery<TDto>
{ }

public interface ICommand : IRequest
{ }
