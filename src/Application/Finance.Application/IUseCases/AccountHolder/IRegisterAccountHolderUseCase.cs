using Finance.Communication.AccountHolder;
using Finance.Communication.AccountHolder.Request;

namespace Finance.Application.IUseCases.AccountHolder;

public interface IRegisterAccountHolderUseCase {
    Task Execute(AccountHolderRequestJson accountHolderRequest);
    string GenerateVerificationCode();
}