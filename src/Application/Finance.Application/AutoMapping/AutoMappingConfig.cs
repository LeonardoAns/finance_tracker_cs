using AutoMapper;
using Domain.Entities;
using Finance.Communication.AccountHolder;
using Finance.Communication.AccountHolder.Request;
using Finance.Communication.Category.Request;
using Finance.Communication.Category.Response;
using Finance.Communication.Expense.Request;
using Finance.Communication.Expense.Response;

namespace Finance.Application.AutoMapping;

public class AutoMappingConfig : Profile{
    
    public AutoMappingConfig(){
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity(){
        CreateMap<CategoryRequestJson, Category>()
            .ForMember(dest => dest.Expenses, opt => opt.Ignore());

        CreateMap<ExpenseRequestJson, Expense>();
        CreateMap<AccountHolderRequestJson, AccountHolder>();
    }

    private void EntityToResponse(){
        CreateMap<Category, CategoryResponseJson>();
        CreateMap<Expense, ExpenseResponseJson>();
    }
}