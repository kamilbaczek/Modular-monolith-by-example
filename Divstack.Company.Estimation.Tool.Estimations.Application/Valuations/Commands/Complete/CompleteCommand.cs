using System;
using Divstack.Company.Estimation.Tool.Estimations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Complete
{
    public sealed class CompleteCommand : ICommand
    {
        public Guid ValuationId { get; set; }
    }
}
