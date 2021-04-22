using System;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors
{
    internal static class ErrorTypes
    {
        private const string NotFound = "NotFound";
        private const string Validation = "Validation";

        internal static bool IsNotFoundException(this Exception exception)
        {
            return  IsType(exception, NotFound);
        }

        internal static bool IsValidationException(this Exception exception)
        {
            return IsType(exception, Validation);
        }

        private static bool IsType(Exception exception, string type)
        {
            return exception.GetType().Name.Contains(type);
        }
    }
}
