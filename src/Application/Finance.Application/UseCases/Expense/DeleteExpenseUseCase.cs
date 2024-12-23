using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Expense;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork){
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long expenseId){
        Expense? expense = await _expenseRepository.FindByIdAsync(expenseId) ?? null;
        await _expenseRepository.DeleteAsync(expense);
        await _unitOfWork.Commit();
    }
}