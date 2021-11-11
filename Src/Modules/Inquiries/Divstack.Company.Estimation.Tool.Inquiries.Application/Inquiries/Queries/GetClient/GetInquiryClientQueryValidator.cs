using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;

public sealed class GetInquiryClientQueryValidator : AbstractValidator<GetInquiryClientQuery>
{
    public GetInquiryClientQueryValidator()
    {
        RuleFor(query => query.InquiryId).NotEmpty();
    }
}
