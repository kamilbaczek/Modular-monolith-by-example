using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Exceptions;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals
{
    public sealed class ProposalDescription : ValueObject
    {
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
