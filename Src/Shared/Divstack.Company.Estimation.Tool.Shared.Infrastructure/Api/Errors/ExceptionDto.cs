namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors;

internal record ExceptionDto(string Message)
{
    internal static ExceptionDto CreateInternalServerError()
    {
        return new ExceptionDto(ErrorMessages.InternalServerError);
    }

    internal static ExceptionDto CreateWithMessage(string message)
    {
        return new ExceptionDto(message);
    }
}
