namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

public record struct ProposalId(Guid Value)
{
    public static ProposalId Create() => new(Guid.NewGuid());
}
