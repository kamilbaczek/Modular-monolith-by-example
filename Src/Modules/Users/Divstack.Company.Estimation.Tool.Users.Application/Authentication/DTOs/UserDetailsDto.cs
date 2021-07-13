using System;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.DTOs
{
    public class UserDetailsDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Guid PublicId { get; set; }
        public bool IsActive { get; set; }
        public string[] Roles { get; set; }
        public Guid ServicerPublicId { get; set; }
        public int CmaxClientId { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
    }
}