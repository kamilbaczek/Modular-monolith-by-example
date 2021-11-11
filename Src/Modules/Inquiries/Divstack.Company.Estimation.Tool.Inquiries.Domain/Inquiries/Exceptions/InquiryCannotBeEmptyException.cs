namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Exceptions;

public sealed class InquiryCannotBeEmptyException : InvalidOperationException
{
    public InquiryCannotBeEmptyException() :
        base("Inquiry cannot be empty")
    {
    }
}
