using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class UpdateCategoryUseCase : IUpdateCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryUseCase(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task Execute(long id, CategoryRequestJson categoryRequest){
        Category? category = await _categoryRepository.FindByIdAsync(id) ?? null;
        await _categoryRepository.UpdateAsync(
            _mapper.Map(categoryRequest, category)
        );
        await _unitOfWork.Commit();
    }
}