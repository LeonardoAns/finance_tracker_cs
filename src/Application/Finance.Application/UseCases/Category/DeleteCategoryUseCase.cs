using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Category;
using Finance.Exception.ExceptionModel;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class DeleteCategoryUseCase : IDeleteCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;


    public DeleteCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IGetAuthContextUseCase getAuthContextUseCase){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task Execute(long id){
        var logedAccount = await _getAuthContextUseCase.Get();
        Category? category = await _categoryRepository.FindByIdAsync(id, logedAccount.Id) ?? 
                             throw new NotFoundException($"Cateogry With Id {id} Not Found");
        await _categoryRepository.DeleteAsync(category);
        await _unitOfWork.Commit();
    }
}