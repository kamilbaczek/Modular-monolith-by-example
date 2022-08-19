namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.Common;

internal static class ValuationStates
{
    public const string WaitForProposal = "WaitForProposal";
    public const string WaitForClientDecision = "WaitForClientDecision";
    public const string Approved = "Approved";
    public const string Completed = "Completed";
}
