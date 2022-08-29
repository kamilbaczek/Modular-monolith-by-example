namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll;

public record struct InquiryListVm(IReadOnlyCollection<InquiryListItemDto> Inquiries);
