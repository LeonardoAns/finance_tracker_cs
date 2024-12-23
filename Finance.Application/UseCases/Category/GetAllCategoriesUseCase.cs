using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase {

    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesUseCase(IMapper mapper, ICategoryRepository categoryRepository){
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryResponseJson>> Execute(){
        List<Category> categories = await _categoryRepository.GetAllAsync();
        return categories.Select(category => _mapper.Map<CategoryResponseJson>(category)).ToList();
    }
}