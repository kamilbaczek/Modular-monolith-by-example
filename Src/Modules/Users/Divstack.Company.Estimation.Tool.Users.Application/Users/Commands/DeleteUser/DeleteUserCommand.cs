namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.DeleteUser;

using System;
using Contracts;

public class DeleteUserCommand : ICommand
{
    public DeleteUserCommand(Guid publicId)
    {
        PublicId = publicId;
    }

    public Guid PublicId { get; }
}
