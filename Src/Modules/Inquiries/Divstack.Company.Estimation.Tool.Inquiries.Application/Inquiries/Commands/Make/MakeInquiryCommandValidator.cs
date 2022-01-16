namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;

using FluentValidation;

public sealed class MakeInquiryCommandValidator : AbstractValidator<MakeInquiryCommand>
{
    public MakeInquiryCommandValidator()
    {
        RuleFor(command => command.Email).EmailAddress().NotEmpty();
        RuleFor(command => command.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(command => command.LastName).NotEmpty().MaximumLength(255);
        RuleFor(command => command.PhoneNumber).NotEmpty();
        RuleForEach(command => command.AskedServiceDtos).NotNull();
    }
}
