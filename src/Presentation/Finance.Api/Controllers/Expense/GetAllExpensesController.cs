using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Expense;

[Route("expenses")]
[ApiController]
[Authorize]
public class GetAllExpensesController : ControllerBase{

    [HttpGet]
    [Route("get/all")]
    public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpenseUseCase useCase){
        List<ExpenseResponseJson> response = await useCase.Execute();
        return Ok(response);
    }
    
}