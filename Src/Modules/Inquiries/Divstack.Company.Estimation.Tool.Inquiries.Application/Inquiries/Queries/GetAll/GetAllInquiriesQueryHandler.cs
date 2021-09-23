using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll
{
    internal sealed class GetAllInquiriesQueryHandler : IRequestHandler<GetAllInquiriesQuery, InquiryListVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetAllInquiriesQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<InquiryListVm> Handle(GetAllInquiriesQuery request, CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();
            var query = @$"SELECT
                               Inquiries.Id AS {nameof(InquiryListItemDto.Id)},
                               Client_FirstName AS {nameof(InquiryListItemDto.FirstName)},
                               Client_LastName AS {nameof(InquiryListItemDto.LastName)},
                               MakeDate AS {nameof(InquiryListItemDto.MakeDate)},
                            FROM
                               Inquiries 
                            ORDER BY
                               MakeDate DESC";

            var inquiryItems = await connection.QueryAsync<InquiryListItemDto>(
                new CommandDefinition(query, cancellationToken));
            var inquiryItemsReadonly = inquiryItems.ToList().AsReadOnly();

            return new InquiryListVm(inquiryItemsReadonly);
        }
    }
}