using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos
{
    public sealed class ValuationInformationDto
    {
        public ValuationInformationDto(Guid id,
            string firstName,
            string lastName,
            string email,
            DateTime requestedDate,
            Guid? completedBy,
            string status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RequestedDate = requestedDate.ToString(Formatting.DateFormat);
            CompletedBy = completedBy;
            Status = status;
            Email = email;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string RequestedDate { get; }
        public Guid? CompletedBy { get; }
        public string Status { get; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
