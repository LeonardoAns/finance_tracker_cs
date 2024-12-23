using Domain.IRepositories;
using Domain.IUnitOfWork;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class DependencyInjectionExtension {

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        AddDbContext(services,configuration);
        AddRepositories(services);
    }

    public static void AddRepositories(IServiceCollection services){
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<FinanceTrackerDbContext>(config =>
            config.UseMySql(connectionString, serverVersion));
    }
    
}