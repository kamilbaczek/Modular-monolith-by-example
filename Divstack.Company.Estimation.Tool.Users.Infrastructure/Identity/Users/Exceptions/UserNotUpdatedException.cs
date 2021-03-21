using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions
{
    [Serializable]
    public class UserNotUpdatedException : Exception
    {
        public UserNotUpdatedException(List<string> errors) : base(
            $"Unable update user by errors: {string.Join(',', errors)}")
        {
        }

        public UserNotUpdatedException() : base("Unable update user")
        {
        }
    }
}