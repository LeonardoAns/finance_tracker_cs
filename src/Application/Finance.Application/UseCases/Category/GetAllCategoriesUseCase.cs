using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase {

    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public GetAllCategoriesUseCase(IMapper mapper, ICategoryRepository categoryRepository, IGetAuthContextUseCase getAuthContextUseCase){
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task<List<CategoryResponseJson>> Execute(){
        var logedAccount = await _getAuthContextUseCase.Get();
        List<Category> categories = await _categoryRepository.GetAllAsync(logedAccount.Id);
        return categories.Select(category => _mapper.Map<CategoryResponseJson>(category)).ToList();
    }
}