namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser;

using System.Collections.Generic;
using Contracts;

public record CreateUserCommand(string FirstName, string LastName, string UserName, string Email, bool IsActive,  List<string> Roles) : ICommand;
