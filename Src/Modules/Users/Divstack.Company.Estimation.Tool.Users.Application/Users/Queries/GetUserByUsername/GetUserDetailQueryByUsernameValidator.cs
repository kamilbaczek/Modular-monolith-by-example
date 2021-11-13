namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;

using FluentValidation;

public class GetUserDetailQueryByUsernameValidator : AbstractValidator<GetUserDetailQueryByUsernameCommand>
{
    public GetUserDetailQueryByUsernameValidator()
    {
        RuleFor(command => command.Username).NotEmpty();
    }
}
