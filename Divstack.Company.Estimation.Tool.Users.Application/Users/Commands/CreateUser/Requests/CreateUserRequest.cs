namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser.Requests
{
    public class CreateUserRequest
    {
        public CreateUserRequest(string userName, string firstName, string lastName, string email, bool isActive)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsActive = isActive;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string UserName { get; }
        public string Email { get; }
        public bool IsActive { get; }
    }
}