using DesafioPicPay.API.Response;
using DesafioPicPay.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioPicPay.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is DesafioPicPayException)
        {
            HandleProjectException(context);
        }
        else
        {
            HandleUnknowException(context);
        }
    }

    public void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException castExceptionErrorOnValidation)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(new ErrorResponse(castExceptionErrorOnValidation.ErrorMessages));
        }
    }
    public void HandleUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ErrorResponse("Erro interno"));
    }
}
