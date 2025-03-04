using Finance.Application.IUseCases.Expense;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Expense;

[Route("expenses")]
[ApiController]
[Authorize]
public class DeleteExpenseController : ControllerBase{

    [HttpDelete]
    [Route("delete/{expenseId}")]
    public async Task<IActionResult> DeleteExpense([FromServices] IDeleteExpenseUseCase useCase,
        [FromRoute] long expenseId){

        await useCase.Execute(expenseId);
        return NoContent();
    }
    
}