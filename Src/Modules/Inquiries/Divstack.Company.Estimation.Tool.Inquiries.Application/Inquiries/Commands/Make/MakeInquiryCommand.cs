using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make
{
    public sealed class MakeInquiryCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> ServicesIds { get; set; }
    }
}
