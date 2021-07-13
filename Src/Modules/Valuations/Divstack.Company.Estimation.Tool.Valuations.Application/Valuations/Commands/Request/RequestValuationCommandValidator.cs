using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    public sealed class RequestValuationCommandValidator : AbstractValidator<RequestValuationCommand>
    {
        public RequestValuationCommandValidator()
        {
            RuleFor(command => command.Email).EmailAddress();
            RuleFor(command => command.FirstName).NotEmpty().MaximumLength(255);
            RuleFor(command => command.LastName).NotEmpty().MaximumLength(255);
            RuleForEach(command => command.ServicesIds).NotNull().NotEmpty();
        }
    }
}