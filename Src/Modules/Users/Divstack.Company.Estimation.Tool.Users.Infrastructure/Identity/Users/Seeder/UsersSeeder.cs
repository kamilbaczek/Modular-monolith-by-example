namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;

using System.Threading.Tasks;
using Application.Authentication;
using Application.Users.Commands.CreateUser.Requests;
using Configuration;
using Domain.Users;
using Utils;

internal sealed class UsersSeeder : IUsersSeeder
{
    private readonly IAdminAccountConfiguration _adminAccountConfiguration;
    private readonly IPasswordsManagementService _passwordsManagementService;
    private readonly IRoleManagementService _roleManagementService;
    private readonly string _systemAdminUserName;
    private readonly IUserManagementService _userManagementService;

    public UsersSeeder(
        IRoleManagementService roleManagementService,
        IUserManagementService userManagementService,
        IAdminAccountConfiguration adminAccountConfiguration,
        IPasswordsManagementService passwordsManagementService)
    {
        _roleManagementService = roleManagementService;
        _userManagementService = userManagementService;
        _adminAccountConfiguration = adminAccountConfiguration;
        _passwordsManagementService = passwordsManagementService;
        _systemAdminUserName = _adminAccountConfiguration.UserName;
    }

    public async Task SeedAdminUserAsync()
    {
        if (!_adminAccountConfiguration.Init)
        {
            return;
        }

        var systemRoleExist = await _roleManagementService.RoleExists(ApplicationRoleKeys.SystemAdministrator);
        if (!systemRoleExist)
        {
            _roleManagementService.AddNewRole(ApplicationRoleKeys.SystemAdministrator).Wait();
        }

        var adminExist = await _userManagementService.UserExists(_adminAccountConfiguration.UserName
        );
        if (adminExist)
        {
            return;
        }

        var createUserRequest = new CreateUserRequest(
            _systemAdminUserName,
            "Admin",
            "System",
            _systemAdminUserName,
            true);

        var userId = AsyncUtil.RunSync(() => _userManagementService.CreateUserAsync(createUserRequest));
        var token = AsyncUtil.RunSync(() =>
            _passwordsManagementService.GenerateConfirmAccountTokenAsync(userId));
        AsyncUtil.RunSync(() =>
            _passwordsManagementService.ConfirmUserEmailAndSetPasswordAsync(userId, token,
                _adminAccountConfiguration.Password));
    }
}
