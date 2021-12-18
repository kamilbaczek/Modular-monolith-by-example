namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Domain;

using Shared.DDD.BuildingBlocks;

internal sealed class Notification
{
    public Guid ValuationId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
    public bool MarkedAsRead { get; set; }
    public DateTime EventDate { get; set; }

    public static Notification Create(Guid valuationId, string title, string text)
    {
        return new Notification
        {
            ValuationId = valuationId,
            Text = text,
            Title = title,
            MarkedAsRead = false,
            EventDate = SystemTime.Now()
        };
    }
}
