using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    public sealed class RequestValuationCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> ServicesIds { get; set; }
    }
}
