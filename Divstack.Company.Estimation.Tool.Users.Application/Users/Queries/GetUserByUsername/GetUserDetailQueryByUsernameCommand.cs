using Divstack.Company.Estimation.Tool.Users.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername
{
    public sealed class GetUserDetailQueryByUsernameCommand : IQuery<UserAccountDto>
    {
        public GetUserDetailQueryByUsernameCommand(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}