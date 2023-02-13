namespace Divstack.Company.Estimation.Tool.Valuations.ArchTests.Common;

using Api.Endpoints.Queries.Get;
using Application.Valuations.Commands.ApproveProposal;
using Extensions;
using Infrastructure.Events.Publish.Configuration;

internal static class Project
{
    internal static readonly Assembly Infrastructure = typeof(ValuationsTopicConfiguration).Assembly;
    internal static string[] InfrastructureParts => Infrastructure.GetMatchingProjects("Infrastructure");
    internal static Assembly Application => typeof(ApproveProposalCommand).Assembly;
    internal static Assembly Api => typeof(GetEndpoint).Assembly;

}
