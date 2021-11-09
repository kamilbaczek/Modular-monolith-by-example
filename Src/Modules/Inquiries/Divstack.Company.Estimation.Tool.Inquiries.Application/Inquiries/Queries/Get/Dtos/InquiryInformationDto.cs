using System;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos
{
    public sealed class InquiryInformationDto
    {
        public InquiryInformationDto(Guid id,
            string firstName,
            string lastName,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string FullName => $"{FirstName} {LastName}";
    }
}