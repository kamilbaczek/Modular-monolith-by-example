namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

using Inquiries.IntegrationsEvents.External;
using Shared.Infrastructure.EventBus;
using Shared.Infrastructure.EventBus.Subscribe;

internal sealed class RequestValuationEventHandler : IIntegrationEventHandler<InquiryMadeEvent>
{
    private readonly IValuationsRepository _valuationsRepository;

    public RequestValuationEventHandler(IValuationsRepository valuationsRepository)
    {
        _valuationsRepository = valuationsRepository;
    }

    public async ValueTask Handle(InquiryMadeEvent @event, CancellationToken cancellationToken = default)
    {
        var inquiryId = new InquiryId(@event.InquiryId);
        var valuation = Valuation.Request(inquiryId);
        await _valuationsRepository.AddAsync(valuation, cancellationToken);
    }
}
