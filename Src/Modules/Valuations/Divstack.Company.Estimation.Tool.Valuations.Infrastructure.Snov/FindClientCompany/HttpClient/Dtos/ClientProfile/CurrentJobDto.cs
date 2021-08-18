namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile
{
    public class CurrentJobDto
    {
        public CurrentJobDto(
            string companyName,
            string position,
            string socialLink,
            string site,
            string locality,
            string state,
            string city,
            string street,
            string street2,
            string postal,
            string founded,
            string startDate,
            string endDate,
            string size,
            string industry,
            string companyType,
            string country
        )
        {
            CompanyName = companyName;
            Position = position;
            SocialLink = socialLink;
            Site = site;
            Locality = locality;
            State = state;
            City = city;
            Street = street;
            Street2 = street2;
            Postal = postal;
            Founded = founded;
            StartDate = startDate;
            EndDate = endDate;
            Size = size;
            Industry = industry;
            CompanyType = companyType;
            Country = country;
        }

        public string CompanyName { get; }
        public string Position { get; }
        public string SocialLink { get; }
        public string Site { get; }
        public string Locality { get; }
        public string State { get; }
        public string City { get; }
        public string Street { get; }
        public string Street2 { get; }
        public string Postal { get; }
        public string Founded { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string Size { get; }
        public string Industry { get; }
        public string CompanyType { get; }
        public string Country { get; }
    }
}