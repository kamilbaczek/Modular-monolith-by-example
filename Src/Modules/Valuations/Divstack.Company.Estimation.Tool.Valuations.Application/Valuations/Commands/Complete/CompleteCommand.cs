namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;

using Common.Contracts;

public record struct CompleteCommand(Guid ValuationId) : ICommand;
