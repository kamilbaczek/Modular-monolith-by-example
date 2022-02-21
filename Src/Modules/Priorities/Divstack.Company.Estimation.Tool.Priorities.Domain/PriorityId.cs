namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public record PriorityId(Guid Value)
{
    public static PriorityId Create()
    {
        return new PriorityId(Guid.NewGuid());
    }

    public static PriorityId Create(Guid id)
    {
        return new PriorityId(id);
    }
}
