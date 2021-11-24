namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions;

using System;
using System.Collections.Generic;

[Serializable]
public class UserNotCreatedException : Exception
{
    public UserNotCreatedException(List<string> errors) : base(
        $"Unable create user by errors: {string.Join(',', errors)}")
    {
    }

    public UserNotCreatedException() : base("Unable create user")
    {
    }
}
