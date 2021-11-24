namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get;

using FluentValidation;

public sealed class GetInquiryQueryValidator : AbstractValidator<GetInquiryQuery>
{
    public GetInquiryQueryValidator()
    {
        RuleFor(query => query.InquiryId).NotEmpty();
    }
}
