﻿namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

public record InquiryId(Guid Value)
{
    public static InquiryId Create()
    {
        return new InquiryId(Guid.NewGuid());
    }

    public static InquiryId Create(Guid value)
    {
        return new InquiryId(value);
    }
}
