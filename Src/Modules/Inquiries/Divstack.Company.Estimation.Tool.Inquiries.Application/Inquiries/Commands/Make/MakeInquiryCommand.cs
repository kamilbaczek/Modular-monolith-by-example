using Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Dtos;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;

public sealed class MakeInquiryCommand : ICommand<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IReadOnlyCollection<AskedServiceDto> AskedServiceDtos { get; set; }
}
