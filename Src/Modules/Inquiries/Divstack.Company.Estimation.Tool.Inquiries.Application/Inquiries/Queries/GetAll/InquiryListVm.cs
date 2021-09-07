using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll
{
    public record InquiryListVm(IReadOnlyCollection<InquiryListItemDto> Inquiries);
}
