using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Contracts
{
    public interface IQuery<TDto> : IRequest<TDto>
    {
    }
}
