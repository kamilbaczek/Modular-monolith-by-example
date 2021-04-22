using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Environments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware
{
    internal sealed class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomExceptionHandlerMiddleware(RequestDelegate next,
            IWebHostEnvironment webHostEnvironment)
        {
            _next = next;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            if (exception.IsNotFoundException())
                code = HttpStatusCode.NotFound;
            if (exception.IsValidationException())
                code = HttpStatusCode.BadRequest;

            var  response = _webHostEnvironment.IsDevelopment() || _webHostEnvironment.IsLocal()
                    ? ExceptionDto.CreateWithMessage(exception.Message)
                    : ExceptionDto.CreateInternalServerError();
            //TODO add logger here

            return SendResponse(context, code, response);
        }

        private static Task SendResponse(HttpContext context, HttpStatusCode code, ExceptionDto response)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            var jsonResponseBody = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(jsonResponseBody);
        }
    }
}
