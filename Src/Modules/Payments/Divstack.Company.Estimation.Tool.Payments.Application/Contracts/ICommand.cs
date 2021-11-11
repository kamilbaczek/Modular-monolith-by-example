using MediatR;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Contracts;

public interface ICommand<TDto> : IQuery<TDto>
{
}

public interface ICommand : IRequest
{
}
