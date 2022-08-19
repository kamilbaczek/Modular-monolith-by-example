namespace Divstack.Company.Estimation.Tool.Valuations.Application.Common.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{ }
