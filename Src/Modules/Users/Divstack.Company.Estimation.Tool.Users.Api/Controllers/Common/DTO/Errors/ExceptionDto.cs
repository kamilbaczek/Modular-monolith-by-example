namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Errors;

using System;
using Newtonsoft.Json;

[Serializable]
public class ExceptionDto
{
    [JsonProperty("message")] public string Message { get; set; }
}
