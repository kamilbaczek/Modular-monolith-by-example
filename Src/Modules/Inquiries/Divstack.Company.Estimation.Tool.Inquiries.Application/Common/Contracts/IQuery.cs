namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;

using MediatR;

public interface IQuery<TDto> : IRequest<TDto>
{
}
