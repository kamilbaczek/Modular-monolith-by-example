using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetAllValuationsQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();
            var query = @$"SELECT
                               Valuations.Id AS {nameof(ValuationListItemDto.Id)},
                               Enquiry_Client_FirstName AS {nameof(ValuationListItemDto.FirstName)},
                               Enquiry_Client_LastName AS {nameof(ValuationListItemDto.LastName)},
                               (SELECT
                                       ValuationsHistory.Status_Value
                                     FROM
                                        ValuationsHistory 
                                     WHERE
                                        ValuationsHistory.ValuationId = Valuations.Id 
                                     ORDER BY
                                        ValuationsHistory.ChangeDate DESC 
                                      LIMIT 1) AS {nameof(ValuationListItemDto.Status)},
                               RequestedDate AS {nameof(ValuationListItemDto.RequestedDate)},
                               CompletedBy AS {nameof(ValuationListItemDto.CompletedBy)} 
                            FROM
                               Valuations 
                            ORDER BY
                               RequestedDate DESC";

            var valuationItems = await connection.QueryAsync<ValuationListItemDto>(
                new CommandDefinition(query, cancellationToken));

            return new ValuationListVm(valuationItems);
        }
    }
}