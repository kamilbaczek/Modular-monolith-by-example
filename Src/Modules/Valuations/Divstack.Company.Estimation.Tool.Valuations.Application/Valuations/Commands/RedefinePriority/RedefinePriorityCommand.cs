
using Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;

public sealed class RedefinePriorityCommand : ICommand
{
    public Guid ValuationId { get; set; }
    public Guid InquiryId { get; set; }
}
