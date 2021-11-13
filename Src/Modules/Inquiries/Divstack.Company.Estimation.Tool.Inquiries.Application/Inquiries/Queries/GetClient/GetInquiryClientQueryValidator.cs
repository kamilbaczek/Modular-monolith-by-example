namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;

using FluentValidation;

public sealed class GetInquiryClientQueryValidator : AbstractValidator<GetInquiryClientQuery>
{
    public GetInquiryClientQueryValidator()
    {
        RuleFor(query => query.InquiryId).NotEmpty();
    }
}
