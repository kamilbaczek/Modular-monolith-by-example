namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors;

internal record ExceptionDto(string Message)
{
    internal static ExceptionDto CreateInternalServerError() => new(ErrorMessages.InternalServerError);

    internal static ExceptionDto CreateWithMessage(string message) => new(message);
}
