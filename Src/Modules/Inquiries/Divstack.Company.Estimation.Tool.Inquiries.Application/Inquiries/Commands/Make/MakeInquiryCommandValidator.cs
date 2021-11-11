using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;

public sealed class MakeInquiryCommandValidator : AbstractValidator<MakeInquiryCommand>
{
    public MakeInquiryCommandValidator()
    {
        RuleFor(command => command.Email).EmailAddress();
        RuleFor(command => command.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(command => command.LastName).NotEmpty().MaximumLength(255);
        RuleForEach(command => command.AskedServiceDtos).NotNull();
    }
}
