using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Expense;

[Route("expenses")]
[ApiController]
[Authorize]
public class GetExpenseByIdController : ControllerBase{

    [HttpGet]
    [Route("get/{expenseId}")]
    public async Task<IActionResult> GetExpenseById([FromServices] IGetExpenseByIdUseCase useCase,
        [FromRoute] long expenseId){

        ExpenseResponseJson response = await useCase.Execute(expenseId);
        return Ok(response);
    }
    
}