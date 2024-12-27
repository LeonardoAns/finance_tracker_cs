using Domain.IRepositories;
using Domain.IUnitOfWork;
using Domain.Security;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Infrastructure.Security.Criptography;
using Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class DependencyInjectionExtension {

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        AddDbContext(services,configuration);
        AddRepositories(services);
        AddToken(services,configuration);
    }

    public static void AddToken(IServiceCollection services, IConfiguration configuration){
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<ITokenGenerator>(config => new TokenGenerator(expirationTimeMinutes,signingKey));
    }

    public static void AddRepositories(IServiceCollection services){
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IAccountHolderRepository, AccountHolderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IPasswordEncripter, PasswordEncoder>();
        services.AddScoped<ITokenProvider, TokenProvider>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<FinanceTrackerDbContext>(config =>
            config.UseMySql(connectionString, serverVersion));
    }
    
}