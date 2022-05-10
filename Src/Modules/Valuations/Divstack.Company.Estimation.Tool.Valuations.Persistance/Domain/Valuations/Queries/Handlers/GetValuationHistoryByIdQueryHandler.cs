namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.GetHistoryById;
using Application.Valuations.Queries.GetHistoryById.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Tool.Valuations.Domain.Valuations;

internal sealed class
    GetValuationHistoryByIdQueryHandler : IRequestHandler<GetValuationHistoryByIdQuery, ValuationHistoryVm>
{
    private const string ProjectionQuery = @"{
                        'HistoricalEntryId':'$HistoricalEntryId.Value',
                        'Status':'$Status.Value',
                        'ChangeDate':1 }";

    private const string History = "History";
    private static readonly string HistoryAsElementName = $"${nameof(History)}";

    private readonly BsonValueAggregateExpressionDefinition<BsonDocument, BsonDocument> _historyElement =
        new(HistoryAsElementName);

    private readonly IValuationsContext _valuationsContext;

    public GetValuationHistoryByIdQueryHandler(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<ValuationHistoryVm> Handle([FromQuery] GetValuationHistoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(request.ValuationId);

        var valuationHistoricalEntries = await _valuationsContext.Valuations.Aggregate()
            .Match(valuation => valuation.ValuationId == valuationId)
            .Unwind(History)
            .ReplaceRoot(_historyElement)
            .Project<ValuationHistoricalEntryDto>(ProjectionQuery)
            .ToListAsync(cancellationToken);

        return new ValuationHistoryVm(valuationHistoricalEntries);
    }
}
