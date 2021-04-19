using MediatR;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Contracts
{
    public interface ICommand<TDto> : IRequest<TDto>
    {
    }

    public interface ICommand : IRequest
    {
    }
}