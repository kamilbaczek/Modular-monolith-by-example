namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;

using MediatR;

public interface ICommand<TDto> : IQuery<TDto>
{
}

public interface ICommand : IRequest
{
}
