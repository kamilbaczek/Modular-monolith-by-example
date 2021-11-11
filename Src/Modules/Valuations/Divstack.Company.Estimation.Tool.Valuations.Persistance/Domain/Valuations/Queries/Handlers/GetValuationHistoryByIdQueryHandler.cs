using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

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

    public async Task<ValuationHistoryVm> Handle(GetValuationHistoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(request.ValuationId);

        var valuationHistoricalEntries = await _valuationsContext.Valuations.Aggregate()
            .Match(valuation => valuation.Id == valuationId)
            .Unwind(History)
            .ReplaceRoot(_historyElement)
            .Project<ValuationHistoricalEntryDto>(ProjectionQuery)
            .ToListAsync(cancellationToken);

        return new ValuationHistoryVm(valuationHistoricalEntries);
    }
}
