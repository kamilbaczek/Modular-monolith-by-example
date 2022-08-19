namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.DeleteUser;

using FluentValidation;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(v => v.PublicId).NotEmpty();
    }
}
