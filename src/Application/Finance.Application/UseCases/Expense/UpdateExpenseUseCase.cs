using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Request;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase {

    private readonly IMapper _mapper;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseUseCase(IMapper mapper, IExpenseRepository expenseRepository, IUnitOfWork unitOfWork){
        _mapper = mapper;
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long expenseId, ExpenseRequestJson expenseRequest){
        Expense? expense = await _expenseRepository.FindByIdAsync(expenseId) ?? null;
        await _expenseRepository.UpdateAsync(
                _mapper.Map(expenseRequest, expense)
            );
        await _unitOfWork.Commit();
    }
}