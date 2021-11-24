namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public record InquiryId(Guid Value)
{
    public static InquiryId Of(Guid guid)
    {
        return new InquiryId(guid);
    }
}
