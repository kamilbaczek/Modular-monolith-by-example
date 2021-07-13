using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn
{
    public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(signInCommand => signInCommand.Password).NotEmpty();
            RuleFor(signInCommand => signInCommand.UserName).NotEmpty();
        }
    }
}