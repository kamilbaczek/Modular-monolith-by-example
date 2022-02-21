namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record ValuationId(Guid Value)
{
    public static ValuationId Create()
    {
        return new ValuationId(Guid.NewGuid());
    }

    public static ValuationId Create(Guid id)
    {
        return new ValuationId(id);
    }
}
