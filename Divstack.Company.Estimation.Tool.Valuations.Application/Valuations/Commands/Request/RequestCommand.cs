using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    public sealed class RequestCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> ProductsIds { get; set; }
    }
}
