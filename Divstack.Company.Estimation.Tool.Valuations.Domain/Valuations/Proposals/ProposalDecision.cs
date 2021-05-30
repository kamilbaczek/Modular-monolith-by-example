using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals
{
    public sealed class ProposalDecision : ValueObject
    {
        private const string Accept = "Accept";

        private const string Reject = "Reject";

        private ProposalDecision()
        {
        }

        private ProposalDecision(DateTime? date, string code)
        {
            Date = date;
            Code = code;
        }

        private DateTime? Date { get; }

        private string Code { get; }

        private bool IsAccepted => Code == Accept;

        private bool IsRejected => Code == Reject;

        internal static ProposalDecision AcceptDecision(DateTime date)
        {
            return new(date, Accept);
        }

        internal static ProposalDecision RejectDecision(DateTime date)
        {
            return new(date, Reject);
        }
    }
}
