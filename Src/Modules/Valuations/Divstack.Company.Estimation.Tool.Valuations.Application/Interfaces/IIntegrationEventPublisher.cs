using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces
{
    public interface IIntegrationEventPublisher
    {
        void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
    }
}
