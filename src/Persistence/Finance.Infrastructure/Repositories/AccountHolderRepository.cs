using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Security;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountHolderRepository : IAccountHolderRepository {

    private FinanceTrackerDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public AccountHolderRepository(FinanceTrackerDbContext dbContext, ITokenProvider tokenProvider){
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task AddAsync(AccountHolder accountHolder){
        await _dbContext.AccountHolders.AddAsync(accountHolder);
    }

    public async Task<bool> ExistsByEmail(string email){
        return await _dbContext.AccountHolders.AsNoTracking().AnyAsync(holder => holder.Email == email);
    }

    public async Task<AccountHolder?> GetByEmail(string email){
        return await _dbContext.AccountHolders.FirstOrDefaultAsync(holder => holder.Email == email);
    }

    public async Task<AccountHolder?> FindByVerificationCode(string verificationCode){
        return await _dbContext.AccountHolders.FirstOrDefaultAsync(holder => holder.VerificationCode == verificationCode);
    }

    public void Update(AccountHolder accountHolder){
         _dbContext.AccountHolders.Update(accountHolder);
    }

    public async Task<AccountHolder?> GetById(){
        string token = _tokenProvider.TokenOnRequest();
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        string id = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;
        long longId = (long)Convert.ChangeType(id, typeof(long));
        return await _dbContext.AccountHolders.FindAsync(longId);
    }
}