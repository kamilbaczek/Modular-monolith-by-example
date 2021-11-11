using MediatR;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;

public interface IQuery<TDto> : IRequest<TDto>
{
}
