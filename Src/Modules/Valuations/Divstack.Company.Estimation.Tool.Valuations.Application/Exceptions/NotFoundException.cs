using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Exceptions
{
    public sealed class NotFoundException : InvalidOperationException
    {
        internal NotFoundException(Guid id, string objectName) : base(GetNotFoundMessage(id, objectName))
        {
        }

        private static string GetNotFoundMessage(Guid id, string objectName)
        {
            return $"{objectName} id: '{id}' not found";
        }
    }
}