using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Contracts;

public interface IQuery<TDto> : IRequest<TDto>
{
}
