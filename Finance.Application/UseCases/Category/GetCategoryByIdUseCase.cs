using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository, IMapper mapper){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponseJson> Execute(long id){
        Category? category = await _categoryRepository.FindByIdAsync(id) ?? null;
        return _mapper.Map<CategoryResponseJson>(category);
    }
}