namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;

using System;
using Contracts;

public sealed class CompleteCommand : ICommand
{
    public Guid ValuationId { get; set; }
}
