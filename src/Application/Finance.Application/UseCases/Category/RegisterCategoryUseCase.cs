using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class RegisterCategoryUseCase : IRegisterCategoryUseCase {

    private readonly IMapper _autoMapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public RegisterCategoryUseCase(IMapper autoMapper, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository){
        _autoMapper = autoMapper;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task Execute(CategoryRequestJson categoryRequest){
        Category category = _autoMapper.Map<Category>(categoryRequest);
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.Commit();
    }
}