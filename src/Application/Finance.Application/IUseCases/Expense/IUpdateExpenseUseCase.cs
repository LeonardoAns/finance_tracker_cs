using Finance.Communication.Expense.Request;

namespace Finance.Application.IUseCases.Expense;

public interface IUpdateExpenseUseCase {
    Task Execute(long expenseId, ExpenseRequestJson expenseRequest);
}