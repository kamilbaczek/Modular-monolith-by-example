using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    public sealed class ValuationListItemDto
    {
        public ValuationListItemDto(Guid id,
            string firstName,
            string lastName,
            DateTime requestedDate,
            Guid? completedBy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RequestedDate = requestedDate.ToString(Formatting.DateFormat);
            CompletedBy = completedBy;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string RequestedDate { get; }
        public Guid? CompletedBy { get; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
