using CashFlow.Application.Interfaces;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ExpenseRegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] ExpenseRequest request, [FromServices] IExpenseRegisterUseCase useCase)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetExpensesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Expenses.Count != 0)
        {
            return Ok(response);
        }
        else
        {
            return NoContent();
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ExpenseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetExpenseById([FromRoute] long id, [FromServices] IGetExpenseByIdUseCase useCase)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateExpense(
     [FromRoute] long id, [FromBody] ExpenseRequest request, [FromServices] IUpdateExpenseUseCase useCase)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteExpense([FromRoute] long id, [FromServices] IDeleteExpenseUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
