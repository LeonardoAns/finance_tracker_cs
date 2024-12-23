using Domain.IUnitOfWork;
using Infrastructure.DbContext;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork{

    private FinanceTrackerDbContext _dbContext;

    public UnitOfWork(FinanceTrackerDbContext dbContext){
        _dbContext = dbContext;
    }


    public async Task Commit(){
        await _dbContext.SaveChangesAsync();
    }
}