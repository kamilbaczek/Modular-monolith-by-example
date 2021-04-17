using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals
{
    public sealed class ProposalDescription : ValueObject
    {
        private ProposalDescription()
        {
        }

        private ProposalDescription(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));
            if(message.Length > 250)
                throw new ProposalDescriptionTooLongException(message);
            Message = message;
        }

        internal static ProposalDescription From(string message)
        {
            return new ProposalDescription(message);
        }

        private string Message { get; }
    }
}
