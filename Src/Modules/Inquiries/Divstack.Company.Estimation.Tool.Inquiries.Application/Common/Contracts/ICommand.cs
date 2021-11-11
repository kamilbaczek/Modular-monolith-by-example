using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;

public interface ICommand<TDto> : IQuery<TDto>
{
}

public interface ICommand : IRequest
{
}
