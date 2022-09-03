namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

public record struct InquiryId(Guid Value)
{
    public static InquiryId Create() => new(Guid.NewGuid());

    public static InquiryId Create(Guid value) => new(value);
}
