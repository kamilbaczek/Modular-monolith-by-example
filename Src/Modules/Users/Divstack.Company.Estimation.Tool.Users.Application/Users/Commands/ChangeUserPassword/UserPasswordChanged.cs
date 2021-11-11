using System;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.ChangeUserPassword;

public class UserPasswordChanged : INotification
{
    public Guid PublicId { get; set; }
}
