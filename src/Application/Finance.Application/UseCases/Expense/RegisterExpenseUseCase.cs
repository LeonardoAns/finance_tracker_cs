using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Request;
using Finance.Exception.ExceptionModel;
using Finance.Exception.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public RegisterExpenseUseCase(IExpenseRepository expenseRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper, 
        ICategoryRepository categoryRepository,
        IGetAuthContextUseCase getAuthContextUseCase){
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task Execute(ExpenseRequestJson expenseRequest){
        Validate(expenseRequest);
        var logedAccount = await _getAuthContextUseCase.Get();
        Category? category = await _categoryRepository.FindByIdAsync(expenseRequest.CategoryId,logedAccount.Id) ?? 
                             throw new NotFoundException($"Cateogry With Id {expenseRequest.CategoryId} Not Found");
        
        Expense expense = _mapper.Map<Expense>(expenseRequest);
        expense.Category = category;
        expense.AccountHolder = logedAccount;
        expense.AccountHolderId = logedAccount.Id;
        await _expenseRepository.AddAsync(expense);
        await _unitOfWork.Commit();
    }
    
    private void Validate(ExpenseRequestJson request){
        ValidationResult? validator = new ExpenseRequestValidator().Validate(request);

        if (!validator.IsValid){
            var errorMessage = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessage);
        }
    }
}