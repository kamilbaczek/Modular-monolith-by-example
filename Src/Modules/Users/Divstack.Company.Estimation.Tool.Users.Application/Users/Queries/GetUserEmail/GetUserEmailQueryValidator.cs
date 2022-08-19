namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;

using FluentValidation;
using GetUser;

public class GetUserEmailQueryValidator : AbstractValidator<GetUserDetailQuery>
{
    public GetUserEmailQueryValidator()
    {
        RuleFor(query => query.PublicId).NotEmpty();
    }
}
