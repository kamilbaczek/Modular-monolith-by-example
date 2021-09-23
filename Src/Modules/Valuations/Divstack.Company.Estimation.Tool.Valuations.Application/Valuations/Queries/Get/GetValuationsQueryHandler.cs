using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Extensions;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get
{
    internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetValuationsQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<ValuationVm> Handle(GetValuationQuery request, CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();

            var valuationInformationDto = await GetInformation(request, connection, cancellationToken);

            return new ValuationVm(valuationInformationDto);
        }

        private static async Task<ValuationInformationDto> GetInformation(
            GetValuationQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"
                SELECT Id AS {nameof(ValuationInformationDto.Id)},
                       InquiryId AS {nameof(ValuationInformationDto.InquiryId)},
                       RequestedDate AS {nameof(ValuationInformationDto.RequestedDate)},
                       CompletedBy AS {nameof(ValuationInformationDto.CompletedBy)},
                       (SELECT
                           ValuationsHistory.Status_Value
                         FROM
                            ValuationsHistory 
                         WHERE
                            ValuationsHistory.ValuationId = Valuations.Id 
                         ORDER BY
                            ValuationsHistory.ChangeDate DESC 
                          LIMIT 1) AS {nameof(ValuationInformationDto.Status)}
                FROM Valuations
                WHERE Id = @ValuationId
                ORDER BY RequestedDate DESC";
            var valuationInformation = await connection.ExecuteSingleQueryAsync<ValuationInformationDto>(
                query, new {request.ValuationId}, cancellationToken);

            return valuationInformation;
        }
    }
}