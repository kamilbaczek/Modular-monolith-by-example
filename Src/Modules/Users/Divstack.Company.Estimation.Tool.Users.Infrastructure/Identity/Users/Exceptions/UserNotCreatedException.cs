using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions;

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
