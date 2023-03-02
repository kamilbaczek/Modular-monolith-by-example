namespace Divstack.Company.Estimation.Tool.Priorities.Application.Common.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{ }
