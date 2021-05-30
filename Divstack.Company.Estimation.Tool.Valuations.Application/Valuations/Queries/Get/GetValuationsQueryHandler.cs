using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            var valuationServices = await GetServices(request, connection, cancellationToken);
            var valuationsDetails = new ValuationDetailsDto(valuationInformationDto, valuationServices);

            return new ValuationVm(valuationsDetails);
        }

        private static async Task<IReadOnlyList<ValuationsServiceItemDto>> GetServices(
            GetValuationQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"SELECT
                [ServiceId] AS {nameof(ValuationsServiceItemDto.ServiceId)}
                FROM [Valuations].[InquiryServices]
                WHERE [EnquiryValuationId] = @ValuationId";
            var valuationServices = await connection.ExecuteQueryAsync<ValuationsServiceItemDto>(
                query, new {request.ValuationId}, cancellationToken);

            return valuationServices.ToList().AsReadOnly();
        }

        private static async Task<ValuationInformationDto> GetInformation(
            GetValuationQuery request,
            IDbConnection connection,
            CancellationToken  cancellationToken)
        {
            var query = @$"
                SELECT [Id] AS {nameof(ValuationInformationDto.Id)},
                       [Enquiry_Client_FirstName] AS {nameof(ValuationInformationDto.FirstName)},
                       [Enquiry_Client_LastName]  AS {nameof(ValuationInformationDto.LastName)},
                       [Enquiry_Client_Email_Value] AS {nameof(ValuationInformationDto.Email)},
                       [RequestedDate] AS {nameof(ValuationInformationDto.RequestedDate)},
                       [CompletedBy] AS {nameof(ValuationInformationDto.CompletedBy)},
                       [Status_Value] AS [{nameof(ValuationInformationDto.Status)}]
                FROM [Valuations].[Valuations]
                WHERE [Id] = @ValuationId
                ORDER BY [RequestedDate] ASC";
            var valuationInformation = await connection.ExecuteSingleQueryAsync<ValuationInformationDto>(
                query, new {request.ValuationId}, cancellationToken);

            return valuationInformation;
        }
    }
}
