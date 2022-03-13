namespace Divstack.Company.Estimation.Tool.Priorities.Common.Contracts;

using MediatR;

public interface ICommand<TDto> : IQuery<TDto>
{
}

public interface ICommand : IRequest
{
}
