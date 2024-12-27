using Domain.Entities;

namespace Domain.IRepositories;

public interface IAccountHolderRepository {
    Task AddAsync(AccountHolder accountHolder);
    Task<bool> ExistsByEmail(string email);
    Task<AccountHolder?> FindByVerificationCode(string verificationCode);
    void Update(AccountHolder accountHolder);
    Task<AccountHolder?> GetByEmail(string email);
    Task<AccountHolder?> GetById();
}