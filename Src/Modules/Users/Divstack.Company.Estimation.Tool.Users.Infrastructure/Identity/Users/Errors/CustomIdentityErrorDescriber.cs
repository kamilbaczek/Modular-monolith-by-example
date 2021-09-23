using Microsoft.AspNetCore.Identity;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Errors
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public static IdentityError PasswordRepeated =>
            new()
            {
                Code = nameof(IndentityErrorsCodes.PasswordRepeated),
                Description = "You can't use a password you have used before."
            };

        public static IdentityError TokenExpired =>
            new()
            {
                Code = nameof(IndentityErrorsCodes.TokenExpired),
                Description = "Token expired."
            };

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
                {Code = IndentityErrorsCodes.EmailAlreadyTaken, Description = $"Email '{email}' is already taken."};
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = IndentityErrorsCodes.UsernameAlreadyTaken,
                Description = $"Username '{userName}' is already taken."
            };
        }
    }
}