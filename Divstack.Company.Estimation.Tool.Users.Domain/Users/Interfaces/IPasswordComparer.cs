namespace Divstack.Company.Estimation.Tool.Users.Domain.Users.Interfaces
{
    public interface IPasswordComparer
    {
        bool AreEqual(UserAccount userAccount, string hashedPassword, string plainTextPassword);
    }
}