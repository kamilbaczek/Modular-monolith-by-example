using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts
{
    public interface ICommand<TDto> : IQuery<TDto>
    {
    }

    public interface ICommand : IRequest
    {
    }
}