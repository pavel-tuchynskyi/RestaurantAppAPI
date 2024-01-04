using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.Common.Exceptions;

namespace RestaurantApp.Web.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var responseException = HandleException(ex, context);
                var response = new RequestResponse<Unit>((int)responseException.Status, Unit.Value, responseException);
                await context.Response.WriteAsJsonAsync(response);
            }
        }

        private ProblemDetails HandleException(Exception ex, HttpContext httpContext)
        {
            ProblemDetails problemDetails = ex switch
            {
                ExceptionBase => HandleApplicationException(ex as ExceptionBase),
                _ => HandleSystemException(ex)
            };

            httpContext.Response.StatusCode = (int)problemDetails.Status;

            return problemDetails;
        }

        private ProblemDetails HandleSystemException(Exception exception)
        {
            var problemDetails = new ProblemDetails();

            problemDetails.Status = 500;
            problemDetails.Type = "Internal server error";
            problemDetails.Title = "Internal server error";
            problemDetails.Detail = "Server encounters an unexpected condition that prevents it from fulfilling the request";

            return problemDetails;
        }

        private ProblemDetails HandleApplicationException(ExceptionBase exception)
        {
            var problemDetails = new ProblemDetails();

            problemDetails.Status = exception.StatusCode;
            problemDetails.Title = exception.Title;
            problemDetails.Type = exception.Type;

            var innerExceptions = new List<ProblemDetails>();
            while (true)
            {
                var innerEx = exception.Pop();

                if (innerEx is NullException)
                {
                    break;
                }

                innerExceptions.Add(HandleApplicationException(innerEx));
            }

            if (innerExceptions.Count > 0)
            {
                problemDetails.Extensions.Add("Errors", innerExceptions);
            }

            problemDetails.Detail = exception.Message;

            return problemDetails;
        }
    }
}
