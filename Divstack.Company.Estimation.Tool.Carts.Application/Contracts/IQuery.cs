using MediatR;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Contracts
{
    public interface IQuery<out TDto> : IRequest<TDto>
    {
    }
}
