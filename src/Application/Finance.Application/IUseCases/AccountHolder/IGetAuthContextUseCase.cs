namespace Finance.Application.IUseCases.AccountHolder;

using Domain.Entities;

public interface IGetAuthContextUseCase {
    Task<AccountHolder> Get();
}