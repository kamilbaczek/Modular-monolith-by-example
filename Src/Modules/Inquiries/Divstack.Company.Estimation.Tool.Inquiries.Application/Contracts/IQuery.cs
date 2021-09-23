using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts
{
    public interface IQuery<TDto> : IRequest<TDto>
    {
    }
}