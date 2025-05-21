using System.Net;
using FinanceControl.Communication.Responses;
using FinanceControl.Exceptions;
using FinanceControl.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace FinanceControl.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FinanceControlExcpetion)
            HandleProjectException(context);
        else
            ThrowUnknownException(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            var excpetion = context.Exception as ErrorOnValidationException;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(excpetion.ErrorMessages));
        }
    }
    
    private void ThrowUnknownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourcesMessagesException.UNKNOWN_ERROR));
    }
}