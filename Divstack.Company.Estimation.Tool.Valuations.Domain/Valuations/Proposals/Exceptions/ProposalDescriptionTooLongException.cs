using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions
{
    public sealed class ProposalDescriptionTooLongException : Exception
    {
        public ProposalDescriptionTooLongException(string message) : base($"'{message}' is too long")
        {
        }
    }
}