using CashFlow.Communication.Responses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

/// <summary>
/// Global exception filter for handling exceptions thrown during the execution of actions in the API.
/// </summary>
public class ExceptionFilter : IExceptionFilter
{
    /// <summary>
    /// Handles exceptions thrown during the execution of an action.
    /// </summary>
    /// <param name="context">The context for the exception.</param>
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectExceptio(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    /// <summary>
    /// Handles exceptions specific to the CashFlow project.
    /// </summary>
    /// <param name="context">The context for the exception.</param>
    private void HandleProjectExceptio(ExceptionContext context)
    {
        var cashFlowException = context.Exception as CashFlowException;

        var errorResponse = new ErrorResponse(cashFlowException!.GetErrors());

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    /// <summary>
    /// Handles unknown errors by returning a generic error response.
    /// </summary>
    /// <param name="context">The context for the exception.</param>
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse(ErrorMessageResource.UNKNOW_ERROR);
        
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
