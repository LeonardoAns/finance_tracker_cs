namespace Finance.Application.IUseCases.Expense;

public interface IDeleteExpenseUseCase {
    Task Execute(long expenseId);
}