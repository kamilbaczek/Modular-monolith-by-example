using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations
{
    public sealed class ValuationStatus : ValueObject
    {
        private const string WaitForProposalStatus = "WaitForProposal";
        private const string WaitForClientDecisionStatus = "WaitForClientDecision";
        private const string RejectedStatus = "Rejected";
        private const string ApprovedStatus = "Approved";
        private const string CompletedStatus = "Completed";
        internal static ValuationStatus WaitForProposal => new(WaitForProposalStatus);
        internal static ValuationStatus WaitForClientDecision => new(WaitForClientDecisionStatus);
        internal static ValuationStatus Rejected => new(RejectedStatus);
        internal static ValuationStatus Approved => new(ApprovedStatus);
        internal static ValuationStatus Completed => new(CompletedStatus);

        private ValuationStatus(string value)
        {
            Value = value;
        }

        internal string Value { get; }
    }
}
