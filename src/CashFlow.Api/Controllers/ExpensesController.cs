using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.BaseExceptions;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] ExpenseRegisterRequest request)
    {
        try
        {
            var response = new ExpenseRegisterUseCase().Execute(request);

            return Created(string.Empty, response);
        }
        catch (ErrorOnValidationException ex)
        {
            return BadRequest(new ErrorResponse(ex.Errors));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse("Unknow Error"));
        }
    }
}
