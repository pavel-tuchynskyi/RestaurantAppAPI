using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Application.Common.Models
{
    public class RequestResponse<T>
    {
        public int StatusCode { get; private set; }
        public T Data { get; private set; }
        public ProblemDetails Exception { get; private set; }

        private RequestResponse()
        {
        }

        public RequestResponse(int statusCode, T data, ProblemDetails exception = null)
        {
            StatusCode = statusCode;
            Data = data;
            Exception = exception;
        }
    }
}
