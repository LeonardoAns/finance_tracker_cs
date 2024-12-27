using AutoMapper;
using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Response;
using Finance.Exception.ExceptionModel;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;
    private readonly IGetAuthContextUseCase _getAuthContextUseCase;

    public GetExpenseByIdUseCase(IExpenseRepository expenseRepository, IMapper mapper, IGetAuthContextUseCase getAuthContextUseCase){
        _expenseRepository = expenseRepository;
        _mapper = mapper;
        _getAuthContextUseCase = getAuthContextUseCase;
    }

    public async Task<ExpenseResponseJson> Execute(long id){
        var logedAccount = await _getAuthContextUseCase.Get();
        Expense? expense = await _expenseRepository.FindByIdAsync(id, logedAccount.Id) ?? 
                           throw new NotFoundException($"Expense With Id {id} Not Found");
        return _mapper.Map<ExpenseResponseJson>(expense);
    }
}