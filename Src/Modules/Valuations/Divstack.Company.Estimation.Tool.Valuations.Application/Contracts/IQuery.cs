namespace Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{
}
