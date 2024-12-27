using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;
using Finance.Exception.ExceptionModel;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository, IMapper mapper, IGetAuthContextUseCase getAuthContextUseCase){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task<CategoryResponseJson> Execute(long id){
        var logedAccount = await _getAuthContextUseCase.Get();
        Category? category = await _categoryRepository.FindByIdAsync(id, logedAccount.Id) ?? 
                             throw new NotFoundException($"Cateogry With Id {id} Not Found");
        return _mapper.Map<CategoryResponseJson>(category);
    }
}