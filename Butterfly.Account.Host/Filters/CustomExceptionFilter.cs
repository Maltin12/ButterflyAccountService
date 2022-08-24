using System.Net;
using Butterfly.Account.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Butterfly.Account.Host.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(((ValidationException)context.Exception).Failures);

                return;
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(new { context.Exception.Message });

        }
    }
}