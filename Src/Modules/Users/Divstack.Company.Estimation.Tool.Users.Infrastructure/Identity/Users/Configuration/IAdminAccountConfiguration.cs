namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration;

internal interface IAdminAccountConfiguration
{
    bool Init { get; }
    string UserName { get; }
    string Email { get; }
    string Password { get; }
}
