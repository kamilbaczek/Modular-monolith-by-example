using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Extensions;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient
{
    internal sealed class GetInquiryClientQueryHandler : IRequestHandler<GetInquiryClientQuery, InquiryClientDto>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetInquiryClientQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<InquiryClientDto> Handle(GetInquiryClientQuery request, CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();
            var query = @$"
                SELECT Client_FirstName AS {nameof(InquiryClientDto.FirstName)},
                       Client_LastName AS {nameof(InquiryClientDto.LastName)},
                       Client_Email_Value AS {nameof(InquiryClientDto.Email)}
                FROM Inquiries
                WHERE Id = @InquiryId";
            var client = await connection.ExecuteSingleQueryAsync<InquiryClientDto>(
                query, new {request.InquiryId}, cancellationToken);

            return client;
        }
    }
}