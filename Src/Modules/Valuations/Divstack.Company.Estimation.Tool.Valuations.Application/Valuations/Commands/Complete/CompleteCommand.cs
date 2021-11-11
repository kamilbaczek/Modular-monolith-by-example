using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;

public sealed class CompleteCommand : ICommand
{
    public Guid ValuationId { get; set; }
}
