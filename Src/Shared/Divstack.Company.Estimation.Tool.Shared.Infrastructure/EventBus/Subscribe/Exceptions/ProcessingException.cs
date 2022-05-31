namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.Exceptions;

public sealed class ProcessingException : InvalidOperationException
{
    public ProcessingException(Exception exception) : base(nameof(ProcessingException), exception)
    {
    }
}
