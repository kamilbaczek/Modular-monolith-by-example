using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication
{
    public interface IRoleManagementService
    {
        Task AddNewRole(string roleName);
        Task<bool> RoleExists(string roleName);
    }
}