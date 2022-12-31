// namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;
//
// using Domain.Valuations;
// using Domain.Valuations.Proposals;
// using Domain.Valuations.Proposals.Events;
// using Shared.DDD.BuildingBlocks.Tests;
//
// internal sealed class ProposalCancelledBuilder
// {
//     public ProposalCancelledBuilder(Valuation valuation)
//     {
//         var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
//         ProposalId = proposalSuggestedDomainEvent.ProposalId;
//         Valuation = valuation;
//         EmployeeId = EmployeeId.Of(Guid.NewGuid());
//     }
//     private static Valuation Valuation { get; set; }
//     private static ProposalId ProposalId { get; set; }
//     private static EmployeeId EmployeeId { get; set; }
//
//     private static Valuation CancelProposal()
//     {
//         Valuation.CancelProposal(ProposalId);
//
//         return Valuation;
//     }
//
//     public static implicit operator Valuation(ProposalCancelledBuilder builder)
//     {
//         return CancelProposal();
//     }
// }


