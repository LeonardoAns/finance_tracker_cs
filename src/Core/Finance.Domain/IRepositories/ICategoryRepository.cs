using Domain.Entities;

namespace Domain.IRepositories;

public interface ICategoryRepository {
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task DeleteAsync(Category category);
    Task<Category?> FindByIdAsync(long id);
    Task UpdateAsync(Category category);
}