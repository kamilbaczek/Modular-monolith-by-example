namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class UserEmailAlreadyTakenException : Exception
{
    protected UserEmailAlreadyTakenException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public UserEmailAlreadyTakenException(string email) : base($"User email: {email} is already taken")
    {
    }
}
