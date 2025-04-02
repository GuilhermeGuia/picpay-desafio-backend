using DesafioPicPay.API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioPicPay.API.Filters;

public class ResponseFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            if (objectResult.Value == null)
                context.Result = new ObjectResult(new ResponseApi<string>(string.Empty));
            else
            {
                var responseType = typeof(ResponseApi<>).MakeGenericType(objectResult.Value.GetType());
                var responseInstance = Activator.CreateInstance(responseType, objectResult.Value);
                context.Result = new ObjectResult(responseInstance);
            }
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
