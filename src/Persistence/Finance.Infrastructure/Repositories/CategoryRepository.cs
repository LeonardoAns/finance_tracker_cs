using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository {

    private FinanceTrackerDbContext _dbContext;

    public CategoryRepository(FinanceTrackerDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task AddAsync(Category category){
        await _dbContext.Categories.AddAsync(category);
    }

    public async Task<List<Category>> GetAllAsync(long accountHolderId){
        return await _dbContext.Categories.AsNoTracking().
            Where(category => category.AccountHolderId == accountHolderId)
            .ToListAsync();
        
    }

    public async Task DeleteAsync(Category category){
         _dbContext.Categories.Remove(category);
    }

    public async Task<Category?> FindByIdAsync(long id, long accountHolderId){
        return await _dbContext.Categories.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id && c.AccountHolderId == accountHolderId);
    }

    public async Task UpdateAsync(Category category){
         _dbContext.Categories.Update(category);
    }
}