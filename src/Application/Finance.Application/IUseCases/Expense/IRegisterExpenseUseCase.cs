using Finance.Communication.Expense.Request;

namespace Finance.Application.IUseCases.Expense;

public interface IRegisterExpenseUseCase {
    Task Execute(ExpenseRequestJson expenseRequest);
}