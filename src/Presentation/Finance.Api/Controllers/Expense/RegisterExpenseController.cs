using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Expense;

[Route("expenses")]
[ApiController]
public class RegisterExpenseController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterExpense([FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] ExpenseRequestJson expenseRequest){

        await useCase.Execute(expenseRequest);
        return Created(String.Empty, null);
    }
    
}