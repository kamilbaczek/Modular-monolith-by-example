namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos;

public sealed class InquiryInformationDto
{
    public InquiryInformationDto(Guid id,
        string firstName,
        string lastName,
        string email,
        int? companySize)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CompanySize = companySize;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public int? CompanySize { get; }

    public string FullName => $"{FirstName} {LastName}";
}
