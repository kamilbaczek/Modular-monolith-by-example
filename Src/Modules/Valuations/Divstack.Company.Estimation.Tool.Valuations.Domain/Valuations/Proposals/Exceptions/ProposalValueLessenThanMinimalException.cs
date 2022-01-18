namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

public sealed class ProposalValueLessenThanMinimalException : InvalidOperationException
{
    private static string GetMessage(Money money, Money minimumValue) => $"Proposal value: {money.Value} {money.Currency} cannot be lessen than {minimumValue.Value} {minimumValue.Currency}";
    public ProposalValueLessenThanMinimalException(Money value, Money minimumValue) : base(GetMessage(value, minimumValue))
    {
    }
}
