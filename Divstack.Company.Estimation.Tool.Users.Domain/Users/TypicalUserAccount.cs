using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Users.Domain.Users
{
    public sealed class TypicalUserAccount
    {
        public Guid PublicId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? Deleted { get; set; }
        public ICollection<FailedLoginAttempt> FailedLoginAttempts { get; set; }
        public ICollection<PasswordHistory> ArchivedPasswords { get; set; }
    }
}