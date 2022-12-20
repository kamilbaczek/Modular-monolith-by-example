namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

public sealed class ValuationProposalEntryDto
{
    public ValuationProposalEntryDto(Guid Id,
        Guid ProposalId,
        string Message,
        string Currency,
        decimal Value,
        DateTime? Suggested,
        Guid? SuggestedBy,
        DateTime? DecisionDate,
        string Decision)
    {
        this.Id = Id;
        this.ProposalId = ProposalId;
        this.Message = Message;
        this.Currency = Currency;
        this.Value = Value;
        this.Suggested = Suggested;
        this.SuggestedBy = SuggestedBy;
        this.DecisionDate = DecisionDate;
        this.Decision = Decision;
    }
    
    public Guid Id { get; init; }
    public Guid ProposalId { get; init; }
    public string Message { get; init; }
    public string Currency { get; init; }
    public decimal Value { get; init; }
    public DateTime? Suggested { get; init; }
    public Guid? SuggestedBy { get; init; }
    public DateTime? DecisionDate { get; private set; }
    public string Decision { get; private set; }
    
    public void Deconstruct(out Guid Id, out Guid ProposalId, out string Message, out string Currency, out decimal Value, out DateTime? Suggested, out Guid? SuggestedBy, out DateTime? DecisionDate, out string Decision)
    {
        Id = this.Id;
        ProposalId = this.ProposalId;
        Message = this.Message;
        Currency = this.Currency;
        Value = this.Value;
        Suggested = this.Suggested;
        SuggestedBy = this.SuggestedBy;
        DecisionDate = this.DecisionDate;
        Decision = this.Decision;
    }
    
    public void SetDecision(DateTime decisionDate, string decision)
    {
        DecisionDate = decisionDate;
        Decision = decision;
    }
}
