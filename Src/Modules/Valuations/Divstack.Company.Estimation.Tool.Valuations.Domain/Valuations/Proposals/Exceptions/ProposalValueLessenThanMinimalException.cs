namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

public sealed class ProposalValueLessenThanMinimalException : InvalidOperationException
{
    public ProposalValueLessenThanMinimalException(Money value, Money minimumValue) : base(GetMessage(value, minimumValue))
    {
    }
    private static string GetMessage(Money money, Money minimumValue)
    {
        return $"Proposal value: {money.Value} {money.Currency} cannot be lessen than {minimumValue.Value} {minimumValue.Currency}";
    }
}
