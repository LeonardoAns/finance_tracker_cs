using Finance.Application.AutoMapping;
using Finance.Application.IUseCases.Category;
using Finance.Application.IUseCases.Expense;
using Finance.Application.UseCases.Category;
using Finance.Application.UseCases.Expense;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application;

public static class DependencyInjectionExtension {

    public static void AddApplication(this IServiceCollection services){
        AddAutoMapper(services);
        AddUseCases(services);
    }

    public static void AddUseCases(this IServiceCollection services){
        //Categories
        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        
        //Expenses
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
    }

    public static void AddAutoMapper(IServiceCollection service){
        service.AddAutoMapper(typeof(AutoMappingConfig));
    }
}