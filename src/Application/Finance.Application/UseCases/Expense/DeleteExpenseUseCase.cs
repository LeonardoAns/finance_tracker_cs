using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Expense;
using Finance.Exception.ExceptionModel;
using Infrastructure.Repositories;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public DeleteExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IGetAuthContextUseCase getAuthContextUseCase){
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task Execute(long expenseId){
        var logedAccount = await _getAuthContextUseCase.Get();
        Expense? expense = await _expenseRepository.FindByIdAsync(expenseId, logedAccount.Id) ?? 
                           throw new NotFoundException($"Expense With Id {expenseId} Not Found");
        await _expenseRepository.DeleteAsync(expense);
        await _unitOfWork.Commit();
    }
}