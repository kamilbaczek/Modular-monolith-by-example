namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Commands.Archive;

using Common.Contracts;

public sealed class ArchivePriorityCommand : ICommand
{
    public Guid ValuationId { get; set; }
}
