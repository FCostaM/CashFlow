using CashFlow.Application.Interfaces.Expenses;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    /// <summary>
    /// Receives a request to register a new expense in the database.
    /// </summary>
    /// <param name="request">The expense request containing the details of the expense to be registered.</param>
    /// <param name="useCase">The use case that handles the registration of the expense.</param>
    /// <returns>A response containing the registered expense details or an error response.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ExpenseRegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] ExpenseRequest request, [FromServices] IExpenseRegisterUseCase useCase)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    /// <summary>
    /// Receives a request to list all expenses registered in the database.
    /// </summary>
    /// <param name="useCase">The use case that handles retrieving all expenses.</param>
    /// <returns>A response containing the list of all expenses or a no content response if there are no expenses.</returns>
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

    /// <summary>
    /// Receives a request to list an expense registered in the database using its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved.</param>
    /// <param name="useCase">The use case that handles retrieving the expense by ID.</param>
    /// <returns>A response containing the expense details if found, or an error response if not found.</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ExpenseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetExpenseById([FromRoute] long id, [FromServices] IGetExpenseByIdUseCase useCase)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    /// <summary>
    /// Receives a request to update data for an expense registered in the database.
    /// </summary>
    /// <param name="id">The ID of the expense to be updated.</param>
    /// <param name="request">The expense request containing the updated details of the expense.</param>
    /// <param name="useCase">The use case that handles updating the expense.</param>
    /// <returns>A no content response if the update is successful, or an error response if the expense is not found or the request is invalid.</returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateExpense([FromRoute] long id, [FromBody] ExpenseRequest request, [FromServices] IUpdateExpenseUseCase useCase)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    /// <summary>
    /// Receives a request to delete an expense from the database.
    /// </summary>
    /// <param name="id">The ID of the expense to be deleted.</param>
    /// <param name="useCase">The use case that handles deleting the expense.</param>
    /// <returns>A no content response if the deletion is successful, or an error response if the expense is not found.</returns>
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
