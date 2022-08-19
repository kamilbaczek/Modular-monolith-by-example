namespace Divstack.Company.Estimation.Tool.Push.DataAccess.Entities;

using Shared.DDD.BuildingBlocks;

public sealed class Notification
{
    public Guid Id { get; init; }
    public Guid ActionId { get; init; }
    public Guid ReceiverId { get; init; }
    public bool MarkedAsRead { get; private set; }
    public DateTime EventDate { get; init; }
    public string? Type { get; init; }

    public static Notification Create(Guid actionId, string type, Guid receiverId)
    {
        return new Notification
        {
            Id = Guid.NewGuid(),
            ActionId = actionId,
            ReceiverId = receiverId,
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
