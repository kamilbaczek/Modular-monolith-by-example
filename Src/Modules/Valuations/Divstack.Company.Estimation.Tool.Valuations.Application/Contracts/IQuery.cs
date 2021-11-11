using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

public interface IQuery<TDto> : IRequest<TDto>
{
}
