namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record struct PriorityId(Guid Value)
{
    public static PriorityId Create() => new(Guid.NewGuid());
}
