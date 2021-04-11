using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals
{
    public sealed class ProposalDecision : ValueObject
    {
        private ProposalDecision()
        {
        }

        private const string Accept = "Accept";

        private const string Reject = "Reject";

        private ProposalDecision(DateTime? date, string code, string rejectReason)
        {
            Date = date;
            Code = code;
            RejectReason = rejectReason;
        }

        private DateTime? Date { get; }

        private string Code { get; }

        private string RejectReason { get; }

        internal static ProposalDecision NoDecision =>
            new ProposalDecision(null,  null, null);

        private bool IsAccepted => Code == Accept;

        private bool IsRejected => Code == Reject;

        internal static ProposalDecision AcceptDecision(DateTime date)
        {
            return new ProposalDecision(date, Accept, null);
        }

        internal static ProposalDecision RejectDecision(DateTime date, string rejectReason)
        {
            return new ProposalDecision(date,  Reject, rejectReason);
        }
    }
}
