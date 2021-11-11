using MediatR;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Contracts
{
    public interface IQuery<TDto> : IRequest<TDto>
    {
    }
}