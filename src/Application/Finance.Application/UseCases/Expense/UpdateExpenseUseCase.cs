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

public class UpdateExpenseUseCase : IUpdateExpenseUseCase {

    private readonly IMapper _mapper;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public UpdateExpenseUseCase(IMapper mapper, IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IGetAuthContextUseCase getAuthContextUseCase){
        _mapper = mapper;
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task Execute(long expenseId, ExpenseRequestJson expenseRequest){
        Validate(expenseRequest);
        var logedAccount = await _getAuthContextUseCase.Get();
        Expense? expense = await _expenseRepository.FindByIdAsync(expenseId, logedAccount.Id) ?? 
                           throw new NotFoundException($"Cateogry With Id {expenseId} Not Found");
        await _expenseRepository.UpdateAsync(
                _mapper.Map(expenseRequest, expense)
            );
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