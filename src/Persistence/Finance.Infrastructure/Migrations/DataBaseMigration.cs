using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Migrations;

public static class DataBaseMigration {
    
    public static async Task Migrate(IServiceProvider service){
        var dbContext = service.GetRequiredService<FinanceTrackerDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}