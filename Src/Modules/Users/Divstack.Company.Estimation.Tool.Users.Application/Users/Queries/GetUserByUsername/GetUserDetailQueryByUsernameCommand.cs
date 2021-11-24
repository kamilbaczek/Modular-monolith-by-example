namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;

using Contracts;

public sealed class GetUserDetailQueryByUsernameCommand : IQuery<UserAccountDto>
{
    public GetUserDetailQueryByUsernameCommand(string username)
    {
        Username = username;
    }

    public string Username { get; }
}
