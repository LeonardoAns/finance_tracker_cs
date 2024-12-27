using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;
using Finance.Exception.ExceptionModel;
using Finance.Exception.Validators;
using FluentValidation.Results;

namespace Finance.Application.UseCases.Category;

using Domain.Entities;

public class RegisterCategoryUseCase : IRegisterCategoryUseCase {

    private readonly IMapper _autoMapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public RegisterCategoryUseCase(IMapper autoMapper, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository, IGetAuthContextUseCase getAuthContextUseCase){
        _autoMapper = autoMapper;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _getAuthContextUseCase = getAuthContextUseCase;
    }
    
    public async Task Execute(CategoryRequestJson categoryRequest){
        Validate(categoryRequest);
        var logedAccount = await _getAuthContextUseCase.Get();
        Category category = _autoMapper.Map<Category>(categoryRequest);
        category.AccountHolder = logedAccount;
        category.AccountHolderId = logedAccount.Id;
        await _categoryRepository.AddAsync(category);
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