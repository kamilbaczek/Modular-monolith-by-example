using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Extensions;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get
{
    internal sealed class GetInquiriesQueryHandler : IRequestHandler<GetInquiryQuery, InquiryVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetInquiriesQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<InquiryVm> Handle(GetInquiryQuery request, CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();

            var valuationInformationDto = await GetInformation(request, connection, cancellationToken);
            var inquiriesServices = await GetServices(request, connection, cancellationToken);
            var inquiriesDetails = new InquiryDetailsDto(valuationInformationDto, inquiriesServices);

            return new InquiryVm(inquiriesDetails);
        }

        private static async Task<IReadOnlyList<InquiriesServiceItemDto>> GetServices(
            GetInquiryQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"SELECT
                Service_ServiceId AS {nameof(InquiriesServiceItemDto.ServiceId)}
                FROM InquiryItemsServices
                WHERE InquiryId = @InquiryId";
            var inquiriesServiceItemDtos = await connection.ExecuteQueryAsync<InquiriesServiceItemDto>(
                query, new {request.InquiryId}, cancellationToken);

            return inquiriesServiceItemDtos.ToList().AsReadOnly();
        }

        private static async Task<InquiryInformationDto> GetInformation(
            GetInquiryQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"
                SELECT Id AS {nameof(InquiryInformationDto.Id)},
                       Client_FirstName AS {nameof(InquiryInformationDto.FirstName)},
                       Client_LastName  AS {nameof(InquiryInformationDto.LastName)},
                       Client_Email_Value AS {nameof(InquiryInformationDto.Email)}
                FROM Inquiries
                WHERE Id = @InquiryId";
            var inquiryInformationDto = await connection.ExecuteSingleQueryAsync<InquiryInformationDto>(
                query, new {request.InquiryId}, cancellationToken);

            return inquiryInformationDto;
        }
    }
}