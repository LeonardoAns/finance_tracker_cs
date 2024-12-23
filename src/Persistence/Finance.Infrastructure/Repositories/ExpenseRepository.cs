using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository {

    private FinanceTrackerDbContext _dbContext;

    public ExpenseRepository(FinanceTrackerDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task AddAsync(Expense expense){
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> GetAllAsync(){
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task DeleteAsync(Expense expense){
        _dbContext.Expenses.Remove(expense);
    }

    public async Task<Expense?> FindByIdAsync(long id){
        return await _dbContext.Expenses.FindAsync(id);
    }

    public async Task UpdateAsync(Expense expense){
        _dbContext.Expenses.Update(expense);
    }
}