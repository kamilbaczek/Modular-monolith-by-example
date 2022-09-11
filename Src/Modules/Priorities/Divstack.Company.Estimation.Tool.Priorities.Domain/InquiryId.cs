namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record InquiryId(Guid Value)
{
    public static InquiryId Create() => new(Guid.NewGuid());

    public static InquiryId Create(Guid id) => new(id);
}
