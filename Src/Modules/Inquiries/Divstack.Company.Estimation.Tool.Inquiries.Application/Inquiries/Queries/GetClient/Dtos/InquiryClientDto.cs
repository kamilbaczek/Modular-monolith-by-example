namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;

public record InquiryClientDto(string FirstName, string LastName, string Email, string PhoneNumber)
{
    public string FullName => $"{FirstName} {LastName}";
}
