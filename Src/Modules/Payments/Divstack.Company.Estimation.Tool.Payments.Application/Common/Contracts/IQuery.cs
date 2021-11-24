namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{
}
