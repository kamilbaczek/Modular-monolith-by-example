namespace Divstack.Company.Estimation.Tool.Push.DataAccess.Entities;

using Shared.DDD.BuildingBlocks;

public sealed class Notification
{
    public Guid Id { get; set; }
    public Guid ValuationId { get; set; }
    public bool MarkedAsRead { get; set; }
    public DateTime EventDate { get; set; }
    public string Type { get; set; }

    public static Notification Create(Guid valuationId, string type)
    {
        return new Notification
        {
            Id = Guid.NewGuid(),
            ValuationId = valuationId,
            MarkedAsRead = false,
            EventDate = SystemTime.Now(),
            Type = type
        };
    }

    public void MarkAsRead()
    {
        MarkedAsRead = true;
    }
}
