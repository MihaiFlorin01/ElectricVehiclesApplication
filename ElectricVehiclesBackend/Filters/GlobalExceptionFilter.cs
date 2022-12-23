using Exceptions;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SchoolOf.ShoppingCart.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var guid = Guid.NewGuid().ToString();
            _logger.LogError(context.Exception, guid);
            context.ExceptionHandled = true;

            if (context.Exception is InvalidParameterException)
            {
                var ex = (InvalidParameterException)context.Exception;
                var response = new ErrorDto
                {
                    Errors = new List<string> { ex.Message }
                };

                context.Result = new JsonResult(response)
                {
                    StatusCode = 400
                };
            }
            else if (context.Exception is InternalValidationException internalValidationException)
            {
                var response = new ErrorDto
                {
                    Errors = internalValidationException.Errors
                };

                context.Result = new JsonResult(response)
                {
                    StatusCode = 400
                };
            }
            else
            {
                var response = new ErrorDto
                {
                    Errors = new List<string> { "Something went wrong. Please contact the support team. Id: " + guid }
                };

                context.Result = new JsonResult(response)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}