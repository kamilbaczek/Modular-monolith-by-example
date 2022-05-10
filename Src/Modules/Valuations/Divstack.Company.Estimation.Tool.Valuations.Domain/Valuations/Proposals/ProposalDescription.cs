namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

using Exceptions;

public sealed class ProposalDescription : ValueObject
{
    private ProposalDescription()
    {
    }

    private ProposalDescription(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message));
        }

        if (message.Length > 250)
        {
            throw new ProposalDescriptionTooLongException(message);
        }

        Message = message;
    }

    public string Message { get; init; }

    internal static ProposalDescription From(string message)
    {
        return new ProposalDescription(message);
    }
}
