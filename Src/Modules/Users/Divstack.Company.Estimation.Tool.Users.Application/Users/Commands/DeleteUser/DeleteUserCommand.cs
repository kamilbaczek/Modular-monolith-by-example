using System;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : ICommand
{
    public DeleteUserCommand(Guid publicId)
    {
        PublicId = publicId;
    }

    public Guid PublicId { get; }
}
