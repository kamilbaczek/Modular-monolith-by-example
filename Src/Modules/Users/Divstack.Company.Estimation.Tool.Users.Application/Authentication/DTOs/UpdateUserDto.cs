using System;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.DTOs;

public class UpdateUserDto
{
    public Guid PublicId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public bool IsActive { get; set; }
}
