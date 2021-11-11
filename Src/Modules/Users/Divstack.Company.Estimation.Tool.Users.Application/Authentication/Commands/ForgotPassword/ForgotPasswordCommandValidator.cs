using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(f => f.UserName)
            .NotEmpty();
    }
}
