using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get
{
    public sealed class GetInquiryQueryValidator : AbstractValidator<GetInquiryQuery>
    {
        public GetInquiryQueryValidator()
        {
            RuleFor(query => query.InquiryId).NotEmpty();
        }
    }
}
