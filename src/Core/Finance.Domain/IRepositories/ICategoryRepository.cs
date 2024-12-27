using Domain.Entities;

namespace Domain.IRepositories;

public interface ICategoryRepository {
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync(long accountHolderId);
    Task DeleteAsync(Category category);
    Task<Category?> FindByIdAsync(long id, long accountHolderId);
    Task UpdateAsync(Category category);
    
    
}