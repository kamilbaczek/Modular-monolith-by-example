namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

public sealed class ValuationListItemDto
{
    public ValuationListItemDto(Guid id, Guid inquiryId, string status, DateTime requestedDate, Guid? completedBy)
    {
        Id = id;
        InquiryId = inquiryId;
        Status = status;
        RequestedDate = requestedDate;
        CompletedBy = completedBy;
    }
    public Guid Id { get; set; }
    public Guid InquiryId { get; set; }
    public string Status { get; set; }
    public DateTime RequestedDate { get; set; }
    public Guid? CompletedBy { get; set; }
}
