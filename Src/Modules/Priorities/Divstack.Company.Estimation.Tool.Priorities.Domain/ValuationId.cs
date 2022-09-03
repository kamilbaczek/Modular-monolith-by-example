namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record ValuationId(Guid Value)
{
    public static ValuationId Create() => new(Guid.NewGuid());

    public static ValuationId Create(Guid id) => new(id);
}
