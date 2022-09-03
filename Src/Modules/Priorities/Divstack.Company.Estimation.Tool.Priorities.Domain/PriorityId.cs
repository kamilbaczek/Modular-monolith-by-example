namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record PriorityId(Guid Value)
{
    public static PriorityId Create() => new(Guid.NewGuid());
}
