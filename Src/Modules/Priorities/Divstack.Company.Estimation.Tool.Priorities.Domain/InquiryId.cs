namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record InquiryId(Guid Value)
{
    public static InquiryId Create()
    {
        return new InquiryId(Guid.NewGuid());
    }

    public static InquiryId Create(Guid id)
    {
        return new InquiryId(id);
    }
}
