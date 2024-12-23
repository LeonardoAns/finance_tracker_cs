using Finance.Communication.Expense.Response;

namespace Finance.Application.IUseCases.Expense;

public interface IGetAllExpenseUseCase {
    Task<List<ExpenseResponseJson>> Execute();
}