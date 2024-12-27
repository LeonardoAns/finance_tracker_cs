using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Expense;

[Route("expenses")]
[ApiController]
[Authorize]
public class UpdateExpenseController : ControllerBase{

    [HttpPut]
    [Route("update/{expenseId}")]
    public async Task<IActionResult> UpdateExpense([FromServices] IUpdateExpenseUseCase useCase,
        [FromRoute] long expenseId, 
        [FromBody] ExpenseRequestJson expenseRequest){

        await useCase.Execute(expenseId, expenseRequest);
        return NoContent();
    }
}