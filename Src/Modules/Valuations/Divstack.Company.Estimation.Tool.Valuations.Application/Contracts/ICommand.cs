using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

public interface ICommand<TDto> : IRequest<TDto>
{
}

public interface ICommand : IRequest
{
}
