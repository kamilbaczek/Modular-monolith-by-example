namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.ChangeUserPassword;

using System;
using MediatR;

public class UserPasswordChanged : INotification
{
    public Guid PublicId { get; set; }
}
