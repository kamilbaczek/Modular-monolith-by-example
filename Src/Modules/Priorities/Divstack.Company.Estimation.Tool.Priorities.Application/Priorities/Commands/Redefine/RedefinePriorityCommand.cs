namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Redefine;

using Common.Contracts;

public sealed class RedefinePriorityCommand : ICommand
{
    public Guid PriorityId { get; set; }
    public Guid ValuationId { get; set; }
    public Guid InquiryId { get; set; }
}
