using iLearning.AccountsManager.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iLearning.AccountsManager.API.Common.Filters.ExceptionFilters;

public class CustomExceptionsFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is ICustomException)
        {
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Value = context.Exception.Message
            };

            context.ExceptionHandled = true;
        }
    }

}
