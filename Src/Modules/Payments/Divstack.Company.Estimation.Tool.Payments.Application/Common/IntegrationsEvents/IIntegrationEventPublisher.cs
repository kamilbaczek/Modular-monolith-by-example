namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.IntegrationsEvents
{
    using Shared.DDD.BuildingBlocks;

    public interface IIntegrationEventPublisher
    {
        Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    }
}
