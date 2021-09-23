using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById
{
    internal sealed class
        GetValuationHistoryByIdQueryHandler : IRequestHandler<GetValuationHistoryByIdQuery, ValuationHistoryVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetValuationHistoryByIdQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<ValuationHistoryVm> Handle(GetValuationHistoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();

            var historicalEntryDtos = await connection.QueryAsync<ValuationHistoricalEntryDto>(
                new CommandDefinition(@$"
                SELECT
                        Id {nameof(ValuationHistoricalEntryDto.Id)}
                       ,Status_Value {nameof(ValuationHistoricalEntryDto.Status)}
                       ,ChangeDate {nameof(ValuationHistoricalEntryDto.ChangeDate)}
                  FROM ValuationsHistory
                  WHERE ValuationId = @ValuationId
                  ORDER BY ChangeDate DESC", new
                {
                    request.ValuationId
                }));


            return new ValuationHistoryVm(historicalEntryDtos);
        }
    }
}