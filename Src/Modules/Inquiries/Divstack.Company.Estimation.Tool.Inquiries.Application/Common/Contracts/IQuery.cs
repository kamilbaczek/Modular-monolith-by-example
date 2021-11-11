using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;

public interface IQuery<TDto> : IRequest<TDto>
{
}
