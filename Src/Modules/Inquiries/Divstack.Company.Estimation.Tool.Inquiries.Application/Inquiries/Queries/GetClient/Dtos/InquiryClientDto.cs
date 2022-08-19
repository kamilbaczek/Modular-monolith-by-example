namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;

public record InquiryClientDto(string FirstName, string LastName, string Email, string PhoneNumber, string CompanySizeAsString)
{
    public int? CompanySize
    {
        get
        {
            var companySize = CompanySizeAsString.Split("-").FirstOrDefault() ?? string.Empty;
            return int.Parse(companySize);
        }
    }

    public string FullName => $"{FirstName} {LastName}";
}
