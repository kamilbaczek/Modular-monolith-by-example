namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Tests;

using Application.Authentication;

internal static class SignInRequestFaker
{
    private const string FakePassword = "qwert12345";
    public static SignInRequest Create() => new(Faker.Internet.Email(), FakePassword);
}
