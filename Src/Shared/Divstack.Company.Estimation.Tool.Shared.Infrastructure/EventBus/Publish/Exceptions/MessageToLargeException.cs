namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Exceptions;

internal sealed class MessageToLargeException : InvalidOperationException
{
    private new const string Message = "The message  is too large to fit in the batch.";
    public MessageToLargeException() : base(Message)
    {
    }
}
