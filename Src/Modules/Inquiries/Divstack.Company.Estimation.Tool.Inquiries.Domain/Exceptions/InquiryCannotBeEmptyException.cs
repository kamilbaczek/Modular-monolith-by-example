using System;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Exceptions;

public sealed class InquiryCannotBeEmptyException : InvalidOperationException
{
    public InquiryCannotBeEmptyException() :
        base("Inquiry cannot be empty")
    {
    }
}
