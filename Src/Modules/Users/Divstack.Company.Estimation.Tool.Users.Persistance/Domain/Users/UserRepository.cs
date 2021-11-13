namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

using System.Threading.Tasks;
using DataAccess;
using Tool.Users.Domain.Users;

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
