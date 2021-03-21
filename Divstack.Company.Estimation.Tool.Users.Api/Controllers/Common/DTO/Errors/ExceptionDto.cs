using System;
using Newtonsoft.Json;

namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Errors
{
    [Serializable]
    public class ExceptionDto
    {
        [JsonProperty("message")] public string Message { get; set; }
    }
}