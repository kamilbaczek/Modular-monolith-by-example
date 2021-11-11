using System;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;

public record InquiryId(Guid Value)
{
    internal static InquiryId Create()
    {
        return new InquiryId(Guid.NewGuid());
    }
}
