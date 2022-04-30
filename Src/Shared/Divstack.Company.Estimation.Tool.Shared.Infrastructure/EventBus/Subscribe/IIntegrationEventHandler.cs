namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;

using System.Threading;
using System.Threading.Tasks;

public interface IIntegrationEventHandler<in TEvent>
{
    ValueTask Handle(TEvent @event, CancellationToken cancellationToken = default);
}
