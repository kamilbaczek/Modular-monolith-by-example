using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById
{
    internal sealed class
       GetValuationProposalsByIdQueryHandler : IRequestHandler<GetValuationProposalsByIdQuery, ValuationProposalsVm>
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public GetValuationProposalsByIdQueryHandler(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<ValuationProposalsVm> Handle(GetValuationProposalsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var connection = _databaseConnectionFactory.Create();

            var valuationProposalEntryDtos = await connection.QueryAsync<ValuationProposalEntryDto>(
                new CommandDefinition(@$"
                   SELECT [Id] {nameof(ValuationProposalEntryDto.Id)}
                          ,[Description_Message]  {nameof(ValuationProposalEntryDto.Message)}
                          ,[Price_Currency] {nameof(ValuationProposalEntryDto.Currency)}
                          ,[Price_Value] {nameof(ValuationProposalEntryDto.Value)}
                          ,[Suggested] {nameof(ValuationProposalEntryDto.Suggested)}
                          ,[SuggestedBy] {nameof(ValuationProposalEntryDto.SuggestedBy)}
                          ,[Decision_Date] {nameof(ValuationProposalEntryDto.DecisionDate)}
                          ,[Decision_Code] {nameof(ValuationProposalEntryDto.Decision)}
                  FROM [Valuations].[Proposals]
                  WHERE ValuationId = @ValuationId
                   ORDER BY [Suggested] DESC", new
                {
                    request.ValuationId
                }));


            return new ValuationProposalsVm(valuationProposalEntryDtos);
        }
    }
}
