namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;

using Common.Contracts;
using Dtos;

public sealed class MakeInquiryCommand : ICommand<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IReadOnlyCollection<AskedServiceDto> AskedServiceDtos { get; set; }
}
