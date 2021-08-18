using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile
{
    public class ClientProfileDto
    {
        public ClientProfileDto(
            bool success,
            int id,
            string source,
            string name,
            string firstName,
            string lastName,
            string logo,
            object industry,
            string country,
            string locality,
            List<SocialDto> social,
            List<CurrentJobDto> currentJobs,
            List<PreviousJobDto> previousJobs,
            string lastUpdateDate
        )
        {
            Success = success;
            Id = id;
            Source = source;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Logo = logo;
            Industry = industry;
            Country = country;
            Locality = locality;
            Social = social;
            CurrentJobs = currentJobs;
            PreviousJobs = previousJobs;
            LastUpdateDate = lastUpdateDate;
        }

        public bool Success { get; }
        public int Id { get; }
        public string Source { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Logo { get; }
        public object Industry { get; }
        public string Country { get; }
        public string Locality { get; }
        public IReadOnlyList<SocialDto> Social { get; }
        public IReadOnlyList<CurrentJobDto> CurrentJobs { get; }
        public IReadOnlyList<PreviousJobDto> PreviousJobs { get; }
        public string LastUpdateDate { get; }
    }
}
