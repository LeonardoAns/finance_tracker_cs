using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Category;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class DeleteCategoryUseCase : IDeleteCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id){
        Category? category = await _categoryRepository.FindByIdAsync(id) ?? null;
        await _categoryRepository.DeleteAsync(category);
        await _unitOfWork.Commit();
    }
}