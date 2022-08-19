namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System.Threading.Tasks;

public interface IRoleManagementService
{
    Task AddNewRole(string roleName);
    Task<bool> RoleExists(string roleName);
}
