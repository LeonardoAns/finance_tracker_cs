using Domain.Entities;

namespace Domain.IRepositories;

public interface IExpenseRepository {
    Task AddAsync(Expense expense);
    Task<List<Expense>> GetAllAsync(long accountHolderId);
    Task DeleteAsync(Expense expense);
    Task<Expense?> FindByIdAsync(long id,long accountHolderId);
    Task UpdateAsync(Expense expense);
}