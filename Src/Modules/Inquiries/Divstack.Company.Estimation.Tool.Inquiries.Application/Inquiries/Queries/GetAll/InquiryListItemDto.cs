namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll;

public sealed class InquiryListItemDto
{
    public InquiryListItemDto(Guid id,
        string firstName,
        string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";
}
