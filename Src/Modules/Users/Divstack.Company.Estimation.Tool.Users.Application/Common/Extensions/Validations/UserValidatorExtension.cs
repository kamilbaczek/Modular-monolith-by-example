namespace Divstack.Company.Estimation.Tool.Users.Application.Common.Extensions.Validations;

using FluentValidation;

internal static class UserValidatorExtension
{
    private const string WrongUserNameMessage =
        "Username should be alphanumeric text that may include _ and – having a length of 3 to 16";

    private const string UserNameRegex = "^[A-Za-z0-9_-]{3,16}$";

    private const string SpecialCharacters = "!\"#$%&'()*+,\\-.\\/:;<=>?@\\[\\]\\^_`{|}~";

    private const string PasswordRegex =
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d" + SpecialCharacters + "]{8,25}$";

    private const string InvalidFormatMessage = "is in invalid format";

    public static void Username<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ruleBuilder.Matches(UserNameRegex).WithMessage(WrongUserNameMessage);
    }

    public static void MustBeCorrectPasswordFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ruleBuilder.Matches(PasswordRegex).WithMessage($"Password {InvalidFormatMessage}");
    }
}
