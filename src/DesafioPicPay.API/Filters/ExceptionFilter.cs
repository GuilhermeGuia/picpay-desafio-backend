using DesafioPicPay.API.Response;
using DesafioPicPay.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioPicPay.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is DesafioPicPayException castDesafioPicPayException)
            HandleProjectException(castDesafioPicPayException, context);
        else
            HandleUnknowException(context);
    }

    public void HandleProjectException(DesafioPicPayException exception, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int) exception.GetStatusCode();
        context.Result = new ObjectResult(new ResponseApi<string>(exception.GetErrorMessages()));
    }

    public void HandleUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseApi<string>(["Erro interno"]));
    }
}
