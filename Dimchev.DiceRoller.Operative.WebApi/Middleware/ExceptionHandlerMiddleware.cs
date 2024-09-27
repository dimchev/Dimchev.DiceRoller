using System.Net;
using FluentValidation;
using Newtonsoft.Json;
using Dimchev.DiceRoller.Common.Core.Exceptions;

namespace Dimchev.DiceRoller.Operative.WebApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    var validationErrors = new
                    {
                        Errors = validationException.Errors
                    };
                    result = JsonConvert.SerializeObject(validationErrors);
                    break;

                case UnauthorizedAccessException unauthorizedException:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    result = JsonConvert.SerializeObject(new
                    {
                        Title = "Unauthorized",
                        Status = (int)httpStatusCode,
                        Detail = unauthorizedException.Message
                    });
                    break;

                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new
                    {
                        Title = "Bad Request",
                        Status = (int)httpStatusCode,
                        Detail = badRequestException.Message
                    });
                    break;

                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(new
                    {
                        Title = "Not Found",
                        Status = (int)httpStatusCode,
                        Detail = notFoundException.Message
                    });
                    break;

                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(new
                    {
                        Title = "Internal Server Error",
                        Status = (int)httpStatusCode,
                        Detail = "An unexpected error occurred."
                    });
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
