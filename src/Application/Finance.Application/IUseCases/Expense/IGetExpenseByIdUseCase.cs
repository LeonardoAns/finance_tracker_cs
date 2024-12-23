using Finance.Communication.Expense.Response;

namespace Finance.Application.IUseCases.Expense;

public interface IGetExpenseByIdUseCase {
    Task<ExpenseResponseJson> Execute(long id);
}