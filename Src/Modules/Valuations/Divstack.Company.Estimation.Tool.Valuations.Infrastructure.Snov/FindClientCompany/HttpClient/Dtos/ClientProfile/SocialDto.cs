namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile
{
    public class SocialDto
    {
        public SocialDto(
            string link,
            string type
        )
        {
            Link = link;
            Type = type;
        }

        public string Link { get; }
        public string Type { get; }
    }
}
