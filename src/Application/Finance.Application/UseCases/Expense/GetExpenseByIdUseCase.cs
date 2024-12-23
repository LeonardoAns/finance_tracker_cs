using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;


    public GetExpenseByIdUseCase(IExpenseRepository expenseRepository, IMapper mapper){
        _expenseRepository = expenseRepository;
        _mapper = mapper;
    }

    public async Task<ExpenseResponseJson> Execute(long id){
        Expense? expense = await _expenseRepository.FindByIdAsync(id) ?? null;
        return _mapper.Map<ExpenseResponseJson>(expense);
    }
}