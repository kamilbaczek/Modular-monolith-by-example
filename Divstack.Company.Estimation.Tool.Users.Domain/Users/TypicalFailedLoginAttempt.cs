using System;

namespace Divstack.Company.Estimation.Tool.Users.Domain.Users
{
    public sealed class TypicalFailedLoginAttempt
    {
        private long Id { get; set; }
        private UserAccount UserAccount { get; set; }
        private DateTime LoginDate { get; set; }
    }
}