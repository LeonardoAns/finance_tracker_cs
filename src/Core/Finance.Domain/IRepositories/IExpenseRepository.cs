using Domain.Entities;

namespace Domain.IRepositories;

public interface IExpenseRepository {
    Task AddAsync(Expense expense);
    Task<List<Expense>> GetAllAsync();
    Task DeleteAsync(Expense expense);
    Task<Expense?> FindByIdAsync(long id);
    Task UpdateAsync(Expense expense);
}