namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;

public interface IIntegrationEventHandler<in TEvent>
{
    ValueTask Handle(TEvent @event, CancellationToken cancellationToken = default);
}
