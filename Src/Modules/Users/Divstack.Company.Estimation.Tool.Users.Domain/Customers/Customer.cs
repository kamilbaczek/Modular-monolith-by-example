using System;

namespace Divstack.Company.Estimation.Tool.Users.Domain.Customers
{
    internal sealed class Customer
    {
        public Customer(Guid publicId, string firstName, string lastName)
        {
            PublicId = publicId;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid PublicId { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}