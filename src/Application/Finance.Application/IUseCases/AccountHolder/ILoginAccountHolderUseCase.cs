using Finance.Communication.AccountHolder.Request;
using Finance.Communication.AccountHolder.Response;

namespace Finance.Application.IUseCases.AccountHolder;

public interface ILoginAccountHolderUseCase {
    Task<AccountHolderResponseJson> Execute(LoginAccountHolderRequestJson accountHolderRequest);
}