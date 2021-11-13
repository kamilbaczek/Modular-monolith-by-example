namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using System;
using Proposals;

public sealed class ProposalNotFoundException : InvalidOperationException
{
    public ProposalNotFoundException(ProposalId proposalId) :
        base($"Proposal: {proposalId} not found.")
    {
    }
}
