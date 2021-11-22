namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

public record ProposalId(Guid Value)
{
    public static ProposalId Create()
    {
        return new ProposalId(Guid.NewGuid());
    }
};
