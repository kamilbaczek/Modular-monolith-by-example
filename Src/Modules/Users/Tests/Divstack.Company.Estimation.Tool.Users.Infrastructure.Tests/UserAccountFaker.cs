namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Tests;

using Domain.Users;

internal static class UserAccountFaker
{
    public static UserAccount Create() => UserAccount.Create(
        Faker.Name.First(),
        Faker.Name.Last(),
        true,
        Faker.Internet.Email());
}
