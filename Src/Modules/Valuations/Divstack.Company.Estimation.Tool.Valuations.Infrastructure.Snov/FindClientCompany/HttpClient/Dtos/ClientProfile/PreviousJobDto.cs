namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile
{
    public class PreviousJobDto
    {
        public PreviousJobDto(
            string companyName,
            string position,
            object socialLink,
            object site,
            object locality,
            object state,
            object city,
            object street,
            object street2,
            object postal,
            object founded,
            string startDate,
            string endDate,
            object size,
            object industry,
            object companyType,
            object country
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
        public object SocialLink { get; }
        public object Site { get; }
        public object Locality { get; }
        public object State { get; }
        public object City { get; }
        public object Street { get; }
        public object Street2 { get; }
        public object Postal { get; }
        public object Founded { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public object Size { get; }
        public object Industry { get; }
        public object CompanyType { get; }
        public object Country { get; }
    }
}
