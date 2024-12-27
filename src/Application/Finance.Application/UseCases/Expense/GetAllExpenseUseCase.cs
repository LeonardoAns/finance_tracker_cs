using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase{
    
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public GetAllExpenseUseCase(IExpenseRepository expenseRepository, IMapper mapper, IGetAuthContextUseCase getAuthContextUseCase){
        _expenseRepository = expenseRepository;
        _mapper = mapper;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task<List<ExpenseResponseJson>> Execute(){
        var logedAccount = await _getAuthContextUseCase.Get();
        List<Expense> expenses = await _expenseRepository.GetAllAsync(logedAccount.Id);
        return expenses.Select(expense => _mapper.Map<ExpenseResponseJson>(expense)).ToList();
    }
}