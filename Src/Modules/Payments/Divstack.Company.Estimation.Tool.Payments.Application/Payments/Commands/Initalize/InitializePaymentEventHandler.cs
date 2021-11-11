using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Payments.Domain.Payments;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Initalize;

internal sealed class InitializePaymentEventHandler : INotificationHandler<ValuationCompleted>
{
    private readonly IPaymentsRepository _paymentsRepository;
    public InitializePaymentEventHandler(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }
    public async Task Handle(ValuationCompleted @event, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(@event.ValuationId);
        var charge = Money.Of(@event.Value, @event.Currency);
        var payment = Payment.Initialize(valuationId, charge);
        await _paymentsRepository.PersistAsync(payment, cancellationToken);
    }
}
