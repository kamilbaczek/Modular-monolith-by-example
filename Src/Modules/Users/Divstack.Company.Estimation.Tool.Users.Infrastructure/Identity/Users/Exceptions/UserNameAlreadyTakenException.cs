namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class UserNameAlreadyTakenException : Exception
{
    protected UserNameAlreadyTakenException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public UserNameAlreadyTakenException(string userName) : base($"UserName: {userName} is already taken")
    {
    }
}
