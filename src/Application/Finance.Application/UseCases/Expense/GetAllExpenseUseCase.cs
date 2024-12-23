using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase{
    
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;

    public GetAllExpenseUseCase(IExpenseRepository expenseRepository, IMapper mapper){
        _expenseRepository = expenseRepository;
        _mapper = mapper;
    }

    public async Task<List<ExpenseResponseJson>> Execute(){
        List<Expense> expenses = await _expenseRepository.GetAllAsync();
        return expenses.Select(expense => _mapper.Map<ExpenseResponseJson>(expense)).ToList();
    }
}