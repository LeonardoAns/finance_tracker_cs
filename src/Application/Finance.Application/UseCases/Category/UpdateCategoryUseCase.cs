using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;
using Finance.Exception.ExceptionModel;
using Finance.Exception.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class UpdateCategoryUseCase : IUpdateCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public UpdateCategoryUseCase(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork, IGetAuthContextUseCase getAuthContextUseCase){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _getAuthContextUseCase = getAuthContextUseCase;
    }


    public async Task Execute(long id, CategoryRequestJson categoryRequest){
        Validate(categoryRequest);
        var logedAccount = await _getAuthContextUseCase.Get();
        Category? category = await _categoryRepository.FindByIdAsync(id, logedAccount.Id) ?? 
                             throw new NotFoundException($"Cateogry With Id {id} Not Found");
        await _categoryRepository.UpdateAsync(
            _mapper.Map(categoryRequest, category)
        );
        await _unitOfWork.Commit();
    }
    
    private void Validate(CategoryRequestJson request){
        ValidationResult? validator = new CategoryRequestValidator().Validate(request);

        if (!validator.IsValid){
            var errorMessage = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessage);
        }
    }
}