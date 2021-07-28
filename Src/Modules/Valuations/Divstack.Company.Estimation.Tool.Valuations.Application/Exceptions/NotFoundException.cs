using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Exceptions
{
    public sealed class NotFoundException : InvalidOperationException
    {
        private static string GetNotFoundMessage(Guid id, string objectName) => $"{objectName} id: '{id}' not found";
        internal NotFoundException(Guid id, string objectName) : base(GetNotFoundMessage(id, objectName))
        {
        }
    }
}
