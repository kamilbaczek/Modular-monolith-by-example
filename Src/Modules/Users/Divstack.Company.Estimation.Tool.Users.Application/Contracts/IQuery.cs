namespace Divstack.Company.Estimation.Tool.Users.Application.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{
}
