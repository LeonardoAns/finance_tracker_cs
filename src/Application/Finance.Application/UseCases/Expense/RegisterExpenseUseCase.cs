using AutoMapper;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.Expense;
using Finance.Communication.Expense.Request;

namespace Finance.Application.UseCases.Expense;

using Domain.Entities;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase {

    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository){
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _categoryRepository = categoryRepository;

    }

    public async Task Execute(ExpenseRequestJson expenseRequest){
        Category? category = await _categoryRepository.FindByIdAsync(expenseRequest.CategoryId) ?? throw new Exception("deu ruim");
        Expense expense = _mapper.Map<Expense>(expenseRequest);
        expense.Category = category;
        await _expenseRepository.AddAsync(expense);
        await _unitOfWork.Commit();
    }
}