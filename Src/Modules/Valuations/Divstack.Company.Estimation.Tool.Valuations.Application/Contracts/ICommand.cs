namespace Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

using MediatR;

public interface ICommand<TDto> : IRequest<TDto>
{
}

public interface ICommand : IRequest
{
}
