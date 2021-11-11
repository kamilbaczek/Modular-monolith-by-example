using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;

namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

internal sealed class UserRepository
{
    private readonly UsersContext _usersContext;

    public UserRepository(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    public async Task AddAsync(UserAccount userAccount)
    {
        await _usersContext.Users.AddAsync(userAccount);
    }
}
