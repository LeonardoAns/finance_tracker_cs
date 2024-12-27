using System.Net;
using System.Text.Json;
using Finance.Exception.ExceptionModel;

namespace Api.Middlewares;

public class ExceptionMiddleware {

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception) {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError; 
        object response = new { };

        if (exception is NotFoundException notFoundException) {
            statusCode = notFoundException.StatusCode; 
            response = new {
                message = notFoundException.Message,
                statusCode = (int)notFoundException.StatusCode 
            };
        } 
        else if (exception is InvalidRequestException invalidRequestException) {
            statusCode = invalidRequestException.StatusCode;
            response = new {
                message = invalidRequestException.Message,
                statusCode = (int)invalidRequestException.StatusCode,
                errors = invalidRequestException.Errors
            };
        }
        else if (exception is BadCredentialsExceptions badCredentialsExceptions) {
            statusCode = badCredentialsExceptions.StatusCode;
            response = new {
                message = badCredentialsExceptions.Message,
                statusCode = (int)badCredentialsExceptions.StatusCode
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
