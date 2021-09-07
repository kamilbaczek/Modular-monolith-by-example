using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
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

            // var valuationInformationDto = await GetInformation(request, connection, cancellationToken);
            // var Inquirieservices = await GetServices(request, connection, cancellationToken);
            // var InquiriesDetails = new ValuationDetailsDto(valuationInformationDto, Inquirieservices);

            return new InquiryVm(InquiriesDetails);
        }

        private static async Task<IReadOnlyList<InquiriesServiceItemDto>> GetServices(
            GetInquiryQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"SELECT
                ServiceId AS {nameof(InquiriesServiceItemDto.ServiceId)}
                FROM InquiryServices
                WHERE EnquiryValuationId = @InquiryId";
            var inquirieServices = await connection.ExecuteQueryAsync<InquiriesServiceItemDto>(
                query, new {request.InquiryId}, cancellationToken);

            return inquirieServices.ToList().AsReadOnly();
        }

        private static async Task<ValuationInformationDto> GetInformation(
            GetValuationQuery request,
            IDbConnection connection,
            CancellationToken cancellationToken)
        {
            var query = @$"
                SELECT Id AS {nameof(ValuationInformationDto.Id)},
                       Enquiry_Client_FirstName AS {nameof(ValuationInformationDto.FirstName)},
                       Enquiry_Client_LastName  AS {nameof(ValuationInformationDto.LastName)},
                       Enquiry_Client_Email_Value AS {nameof(ValuationInformationDto.Email)},
                       RequestedDate AS {nameof(ValuationInformationDto.RequestedDate)},
                       CompletedBy AS {nameof(ValuationInformationDto.CompletedBy)},
                FROM Inquiries
                WHERE Id = @InquiryId
                ORDER BY RequestedDate DESC";
            var valuationInformation = await connection.ExecuteSingleQueryAsync<ValuationInformationDto>(
                query, new {request.InquiryId}, cancellationToken);

            return valuationInformation;
        }
    }
}
