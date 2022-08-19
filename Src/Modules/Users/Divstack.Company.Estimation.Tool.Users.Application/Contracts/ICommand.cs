namespace Divstack.Company.Estimation.Tool.Users.Application.Contracts;

using MediatR;

public interface ICommand<TDto> : IRequest<TDto>
{ }

public interface ICommand : IRequest
{ }
