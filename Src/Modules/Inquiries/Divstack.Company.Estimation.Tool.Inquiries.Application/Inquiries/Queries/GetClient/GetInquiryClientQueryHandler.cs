﻿namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;

using Dtos;
using MediatR;

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
        const string query = @$"
                SELECT Client_FirstName AS {nameof(InquiryClientDto.FirstName)},
                       Client_LastName AS {nameof(InquiryClientDto.LastName)},
                       Client_Email_Value AS {nameof(InquiryClientDto.Email)},
                       Client_PhoneNumber_Value AS {nameof(InquiryClientDto.PhoneNumber)},
                       Client_Company_Size AS {nameof(InquiryClientDto.CompanySizeAsString)}
                FROM Inquiries
                WHERE Id = @InquiryId";
        var client = await connection.ExecuteSingleQueryAsync<InquiryClientDto>(
            query, new
            {
                request.InquiryId
            }, cancellationToken);

        return client;
    }
}
