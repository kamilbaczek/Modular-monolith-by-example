using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Contracts
{
    public interface ICommand<TDto> : IRequest<TDto>
    {
    }

    public interface ICommand : IRequest
    {
    }
}