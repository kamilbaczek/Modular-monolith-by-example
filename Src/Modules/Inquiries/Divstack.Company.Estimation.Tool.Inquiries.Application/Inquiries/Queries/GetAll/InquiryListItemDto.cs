using System;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Constants;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll
{
    public sealed class InquiryListItemDto
    {
        public InquiryListItemDto(Guid id,
            string firstName,
            string lastName,
            DateTime makeDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MakeDate = makeDate.ToString(Formatting.DateFormat);
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MakeDate { get; }
        public string FullName => $"{FirstName} {LastName}";
    }
}