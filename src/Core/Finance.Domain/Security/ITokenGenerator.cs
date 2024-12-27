using Domain.Entities;

namespace Domain.Security;

public interface ITokenGenerator {
    string GenerateToken(AccountHolder accountHolder);
}