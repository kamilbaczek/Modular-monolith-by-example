namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;

public class ValuationInformationDto
{
    public ValuationInformationDto()
    {
    }
    public ValuationInformationDto(Guid Id,
        string Status,
        Guid InquiryId,
        Guid? CompletedBy,
        DateTime RequestedDate)
    {
        this.Id = Id;
        this.Status = Status;
        this.InquiryId = InquiryId;
        this.CompletedBy = CompletedBy;
        this.RequestedDate = RequestedDate;
    }
    public Guid Id { get; set; }
    public string Status { get; set; }
    public Guid InquiryId { get; set; }
    public Guid? CompletedBy { get; set; }
    public DateTime RequestedDate { get; set; }
}
