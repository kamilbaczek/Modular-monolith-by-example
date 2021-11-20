namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

public sealed class ProposalDescriptionTooLongException : InvalidOperationException
{
    public ProposalDescriptionTooLongException(string message) : base($"'{message}' is too long")
    {
    }
}
